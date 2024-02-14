using CatenarySupport.Attributes;
using CatenarySupport.Database.Tables;
using CatenarySupport.Providers;
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

        private readonly IProvider<MastData> MastProvider;
        private readonly IProvider<MastTypeData> MastTypeProvider;
        private readonly IProvider<PlantData> PlantProvider;
        private readonly IProvider<DistrictData> DistrictProvider;

        public Main(IProvider<MastData> mast_provider, IProvider<MastTypeData> mast_type_provider, IProvider<PlantData> plant_data_provider, IProvider<DistrictData> district_provider)

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
            SetColumnParams(typeof(MastData), gridControl.RepositoryItems);

            gridview_masts.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            gridview_masts.CustomRowCellEditForEditing += (sender, e) =>
            {
                var item = gridControl.RepositoryItems[e.Column.FieldName];
                if (item != null)
                    e.RepositoryItem = item;
            };

            gridview_masts.RowUpdated += (sender, e) =>
            {
                var updated_mast = (e.Row as MastData);
                
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

                var deleted_mast = (e.Row as MastData);
                MastProvider.Delete(deleted_mast!);
#if DEBUG
                Debug.WriteLine("DELETE MAST UUID: " + deleted_mast!.UUID);
#endif
            };

            BindingList<MastData> masts = new BindingList<MastData>();

            MastProvider.Select().ForEach(masts.Add);
            gridControl.DataSource = masts;

            //скрываем коллнки не имеющие атрибут DisplayName
            typeof(MastData).GetProperties()
                .Where((p) => p.GetAttribute<DisplayNameAttribute>() == null)
                .ForEach(f => gridview_masts.Columns[f.Name].Visible = false);


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