using CatenarySupport.Attributes;
using CatenarySupport.Providers;
using CatenarySupport.Providers.Objects;
using DevExpress.Internal;
using DevExpress.Xpf.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid;
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
        private readonly IProvider<ProtocolObject> ProtocolProvider;

        public Main(IProvider<MastObject> mast_provider, IProvider<MastTypeObject> mast_type_provider, IProvider<PlantObject> plant_provider, 
            IProvider<DistrictObject> district_provider, IProvider<ProtocolObject> protocol_provider)

        {

            Providers = new Dictionary<Type, object>
            {
                    { mast_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], mast_provider },
                    { mast_type_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], mast_type_provider },
                    { plant_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], plant_provider },
                    { district_provider.GetType().GetInterface("IProvider`1")!.GetGenericArguments()[0], district_provider }
            };
            
            MastProvider = mast_provider;
            MastTypeProvider = mast_type_provider;
            PlantProvider = plant_provider;
            DistrictProvider = district_provider;
            ProtocolProvider = protocol_provider;

            InitializeComponent();

        }


        private void Main_Shown(object sender, EventArgs e)
        {
            gridview_masts.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            gridview_masts.CustomRowCellEditForEditing += (sender, e) =>
            {
                var item = gridcontrol_masts.RepositoryItems[e.Column.FieldName];
                if (item != null)
                    e.RepositoryItem = item;
            };
            gridview_masts.RowUpdated += Gridview_masts_RowUpdated;
            gridview_masts.RowDeleting += Gridview_masts_RowDeleting;
            SetColumnParams(typeof(MastObject), gridcontrol_masts.RepositoryItems);

            BindingSource bindingSource_masts = new BindingSource();
            bindingSource_masts.AddCollection(MastProvider.Select());

            gridcontrol_masts.MainView = gridview_masts;
            gridcontrol_masts.DataSource = bindingSource_masts;


            gridview_protocols.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            gridview_protocols.CustomRowCellEditForEditing += (sender, e) =>
            {
                var item = gridcontrol_masts.RepositoryItems[e.Column.FieldName];
                if (item != null)
                    e.RepositoryItem = item;
            };
            gridview_protocols.RowUpdated += Gridview_protocols_RowUpdated;
            gridview_protocols.RowDeleting += Gridview_protocols_RowDeleting;
            //SetColumnParams(typeof(MastObject), gridcontrol_protocols.RepositoryItems);

            BindingSource bindingSource_protocols = new BindingSource();
            bindingSource_protocols.AddCollection(ProtocolProvider.Select());

            gridcontrol_protocols.MainView = gridview_protocols;
            gridcontrol_protocols.DataSource = bindingSource_protocols;



        }

        private void Gridview_masts_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
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
        }
        private void Gridview_masts_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
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
        }

        private void Gridview_protocols_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (XtraMessageBox.Show("Delete row(s)?", "Delete rows dialog", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            var deleted_protocol = (e.Row as ProtocolObject);
            ProtocolProvider.Delete(deleted_protocol!);
#if DEBUG
            Debug.WriteLine("DELETE PROTOCOL UUID: " + deleted_protocol!.UUID);
#endif
        }
        private void Gridview_protocols_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var updated_protocol = (e.Row as ProtocolObject);

            if (e.RowHandle == DataControlBase.NewItemRowHandle)
            {
                ProtocolProvider.Insert(updated_protocol!);

#if DEBUG
                Debug.WriteLine("INSERT PROTOCOL UUID: " + updated_protocol!.UUID);
#endif
            }
            else
            {

                ProtocolProvider.Update(updated_protocol!);
#if DEBUG
                Debug.WriteLine("UPDATE PROTOCOL UUID: " + updated_protocol!.UUID);
#endif

            }
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