using CatenarySupport.Attributes;
using CatenarySupport.Providers;
using CatenarySupport.Providers.Objects;
using DevExpress.Internal;
using DevExpress.Xpf.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB.Extensions;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace CatenarySupport
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private readonly Dictionary<Type, object> Providers;

        private readonly IProvider<MastObject> MastProvider;
        private readonly IProvider<MastTypeObject> MastTypeProvider;
        private readonly IProvider<PlantObject> PlantProvider;
        private readonly IProvider<DistrictObject> DistrictProvider;

        public Main(IProvider<MastObject> mast_provider, IProvider<MastTypeObject> mast_type_provider, IProvider<PlantObject> plant_data_provider, IProvider<DistrictObject> district_provider)

        {

            Providers = new Dictionary<Type, object>
            {
                    { mast_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], mast_provider },
                    { mast_type_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], mast_type_provider },
                    { plant_data_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], plant_data_provider },
                    { district_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], district_provider }
            };
            
            MastProvider = mast_provider;
            MastTypeProvider = mast_type_provider;
            PlantProvider = plant_data_provider;
            DistrictProvider = district_provider;

            InitializeComponent();

        }


        private void Main_Shown(object sender, EventArgs e)
        {
            SetColumnParams(typeof(MastObject), gridControl.RepositoryItems);

            gridview_masts.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            gridview_masts.CustomRowCellEditForEditing += (sender, e) =>
            {
                var item = gridControl.RepositoryItems[e.Column.FieldName];
                if (item != null)
                    e.RepositoryItem = item;
            };


                gridview_masts.RowUpdated += (sender, e) =>
            {
                var updated_mast = (e.Row as MastObject);

                if (e.RowHandle == DataControlBase.NewItemRowHandle)
                {
                    MastProvider.Insert(updated_mast!);

#if DEBUG
                    Debug.WriteLine("INSERT MAST UUID: " + updated_mast!.UUID);
#endif
                }
                else
                {

                    MastProvider.Update(updated_mast!);
#if DEBUG
                    Debug.WriteLine("UPDATE MAST UUID: " + updated_mast!.UUID);
#endif

                }
            };
            gridview_masts.RowDeleting += (sender, e) =>
            {
                if (XtraMessageBox.Show("Delete row(s)?", "Delete rows dialog", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                var deleted_mast = (e.Row as MastObject);
                MastProvider.Delete(deleted_mast!);
#if DEBUG
                Debug.WriteLine("DELETE MAST UUID: " + deleted_mast!.UUID);
#endif
            };

            BindingSource bindingSource = new BindingSource();
            bindingSource.AddCollection(MastProvider.Select());

            gridControl.DataSource = bindingSource;

            //скрываем коллнки не имеющие атрибут DisplayName
            typeof(MastObject).GetProperties()
                .Where((p) => p.GetAttribute<DisplayNameAttribute>() == null)
                .ForEach(f => gridview_masts.Columns[f.Name].Visible = false);




        }

        private void Gridview_masts_ShowingEditor(object? sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetColumnParams(Type type, RepositoryItemCollection repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            var attributes = type.GetProperties()
                .SelectNotNull((p) => p.GetAttribute<BaseColumnAttribute>()!).ToArray();

            foreach(var att in attributes)
            {
                var arg = Providers.GetValueOrDefault(att!.BindedTable ?? new object().GetType())!;

                var binding_out = att.OnBindingFunction?.Invoke(arg);

                if (binding_out != null)
                    repository.Add(binding_out);
            }
        }
    }
}