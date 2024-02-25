using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatenarySupport.Attributes;
using CatenarySupport.Providers;
using CatenarySupport.Providers.View;
using DevExpress.Internal;
using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraMap;
using FluentValidation;
using LinqToDB.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CatenarySupport
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private readonly IViewProvider<MastView> MastViewProvider;
        private readonly IViewProvider<MastTypeView> MastTypeViewProvider;
        private readonly IViewProvider<PlantView> PlantViewProvider;
        private readonly IViewProvider<DistrictView> DistrictViewProvider;
        private readonly IViewProvider<ProtocolView> ProtocolViewProvider;
        private readonly IViewProvider<DefectView> DefectViewProvider;
        private readonly IViewProvider<MeasurmentView> MeasurmentViewProvider;


        public Main(IViewProvider<MastView> mast_provider, IViewProvider<MastTypeView> mast_type_provider, IViewProvider<PlantView> plant_provider,
            IViewProvider<DistrictView> district_provider, IViewProvider<ProtocolView> protocol_provider, IViewProvider<DefectView> defect_provider,
            IViewProvider<MeasurmentView> measurment_provider)
        {
            MastViewProvider = mast_provider;
            MastTypeViewProvider = mast_type_provider;
            PlantViewProvider = plant_provider;
            DistrictViewProvider = district_provider;
            ProtocolViewProvider = protocol_provider;
            DefectViewProvider = defect_provider;
            MeasurmentViewProvider = measurment_provider;


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
            gridview_masts.ValidateRow += Gridview_masts_ValidateRow;

            SetColumnParams(typeof(MastView), gridcontrol_masts.RepositoryItems);

            BindingSource bindingSource_masts = new BindingSource();
            bindingSource_masts.DataSource = typeof(MastView);
            bindingSource_masts.AddCollection(MastViewProvider.Select());

            gridview_masts.OptionsDetail.DetailMode = DetailMode.Embedded;
            gridview_masts.MasterRowGetLevelDefaultView += (s, e) => {
                
                if (e.RelationIndex == 0)
                {
                    //делаем view для детализации протоклов
                    var view = (gridcontrol_masts.CreateView("GridView") as GridView)!;
                    view.OptionsSelection.EnableAppearanceFocusedCell = false;
                    view.OptionsBehavior.Editable = false;
                    view.OptionsView.ShowGroupPanel = false;
                    e.DefaultView = view;

                }
                if (e.RelationIndex == 1)
                {
                    //делаем view для детализации дефектов
                    var view = (gridcontrol_masts.CreateView("GridView") as GridView)!;
                    view.RowCellDefaultAlignment += (s, e) => {
                        e.HorzAlignment =  HorzAlignment.Center;
                    };

                    view.OptionsView.GroupFooterShowMode = GroupFooterShowMode.Hidden;
                    view.OptionsSelection.EnableAppearanceFocusedCell = false;
                    view.OptionsBehavior.Editable = false;
                    view.OptionsView.ShowGroupPanel = false;

                    view.RowHeight = 150;

                    e.DefaultView = view;
                }
            };


            gridview_masts.MasterRowEmpty += (s, e) => {
                //здесь нужно чекнуть есть измерения для опоры
                //если нету то соответсвенно нужно установить e.IsEmpty = true;
                var selected_mast = (gridview_masts.GetRow(e.RowHandle) as MastView)!;

#if DEBUG
                Debug.WriteLine("CHECK DETILED VIEW FOR MAST: " + selected_mast.UUID);
#endif

                if (MeasurmentViewProvider.Select(m => m.MastUUID == selected_mast.UUID).Any())
                    e.IsEmpty = false;
                else
                    e.IsEmpty = true;
            };

            gridview_masts.MasterRowGetRelationCount += (s, e) => {
                e.RelationCount = 2;
            };

            gridview_masts.MasterRowGetRelationName += (s, e) => {
                switch(e.RelationIndex)
                {
                    case 0:
                        e.RelationName = "Протоколы";
                        break;
                    case 1:
                        e.RelationName = "Дефекты";
                        break;
                }
            };

            gridview_masts.MasterRowGetChildList += async (s, e) => {

                var selected_mast = (gridview_masts.GetRow(e.RowHandle) as MastView)!;
                var mesurments = MeasurmentViewProvider.Select(m => m.MastUUID == selected_mast.UUID);

                switch (e.RelationIndex)
                {
                    //здесь можно получить коллекцию с MeasurmentData c фильром по опоре и
                    //из нее уже слепить таблицу с протоколами и таблицу дефектами

                    case 0:
#if DEBUG
                        Debug.WriteLine("GET DETILED VIEW PROTOCOLS FOR MAST: " + selected_mast.UUID);
#endif

                        BindingList<ProtocolSmallView> protocols = new BindingList<ProtocolSmallView>
                        {
                            AllowEdit = false,
                            AllowNew = false,
                            AllowRemove = false
                        };

                        e.ChildList = protocols;

                        MapperConfiguration mapper_config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateProjection<ProtocolView, ProtocolSmallView>();
                        });

                        mesurments.SelectMany(measurment => ProtocolViewProvider.Select(protocol => protocol.UUID == measurment.ProtocolUUID))
                            .AsQueryable()
                            .ProjectTo<ProtocolSmallView>(mapper_config)
                            .ForEach(protocols.Add);

                        break;
                    case 1:
#if DEBUG
                        Debug.WriteLine("GET DETILED VIEW DEFECTS FOR MAST: " + selected_mast.UUID);
#endif

                        BindingList<DefectView> defects = new BindingList<DefectView>
                        {
                            AllowEdit = false,
                            AllowNew = false,
                            AllowRemove = false
                        };

                        e.ChildList = defects;

                        mesurments.SelectMany(measurment => DefectViewProvider.Select(defect => defect.MeasurmentUUID == measurment.UUID))
                            .ForEach(defects.Add);

                        if (e.ChildList.Count == 0) 
                            XtraMessageBox.Show("Дефектов для опоры не найдено", "Информация", MessageBoxButtons.OK);

                        break;
                }

            };


            gridcontrol_masts.MainView = gridview_masts;
            gridcontrol_masts.DataSource = bindingSource_masts;

            //gridview_protocols.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            //gridview_protocols.CustomRowCellEditForEditing += (sender, e) =>
            //{
            //    var item = gridcontrol_masts.RepositoryItems[e.Column.FieldName];
            //    if (item != null)
            //        e.RepositoryItem = item;
            //};
            //gridview_protocols.RowUpdated += Gridview_protocols_RowUpdated;
            //gridview_protocols.RowDeleting += Gridview_protocols_RowDeleting;
            //gridview_protocols.ValidateRow += Gridview_protocols_ValidateRow;
            //SetColumnParams(typeof(ProtocolView), gridcontrol_masts.RepositoryItems);

            //BindingSource bindingSource_protocols = new BindingSource();
            //bindingSource_protocols.DataSource = typeof(ProtocolView);
            //bindingSource_protocols.AddCollection(ProtocolViewProvider.Select());
            //gridcontrol_protocols.MainView = gridview_protocols;
            //gridcontrol_protocols.DataSource = bindingSource_protocols;


            //gridview_measurments.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            //gridview_measurments.CustomRowCellEditForEditing += (sender, e) =>
            //{
            //    var item = gridcontrol_masts.RepositoryItems[e.Column.FieldName];
            //    if (item != null)
            //        e.RepositoryItem = item;
            //};
            //gridview_measurments.OptionsDetail.DetailMode = DetailMode.Embedded;
            //gridview_measurments.OptionsDetail.AllowExpandEmptyDetails = true;
            ////gridview_protocols.RowUpdated += Gridview_protocols_RowUpdated;
            ////gridview_protocols.RowDeleting += Gridview_protocols_RowDeleting;
            ////gridview_protocols.ValidateRow += Gridview_protocols_ValidateRow;
            //SetColumnParams(typeof(MeasurmentView), gridcontrol_masts.RepositoryItems);

            //BindingSource bindingSource_measurments= new BindingSource();
            //bindingSource_measurments.DataSource = typeof(MeasurmentView);
            ////bindingSource_measurments.AddCollection(ProtocolViewProvider.Select());

            //gridcontrol_measurments.MainView = gridview_measurments;
            //gridcontrol_measurments.DataSource = bindingSource_measurments;


        }

        private void Gridview_masts_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var validate_mast = (e.Row as MastView);
            if (validate_mast!.UUID == null)
                validate_mast!.UUID = Guid.NewGuid().ToString();

            var result = ValidateViewObject<MastView, MastViewValidator>(validate_mast);

            e.ErrorText = result;
            e.Valid = result is null;
        }
        private void Gridview_protocols_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var validate_protocol = (e.Row as ProtocolView);
            if (validate_protocol!.UUID == null)
                validate_protocol!.UUID = Guid.NewGuid().ToString();

            var result = ValidateViewObject<ProtocolView, ProtocolViewValidator>(validate_protocol);

            e.ErrorText = result;
            e.Valid = result is null;
        }

        private static string? ValidateViewObject<T,Y>(T view_model) where Y : AbstractValidator<T>, new() 
        {
            var validator = new Y();
            var result = validator!.Validate(view_model);

            if (!result.IsValid)
            {
                var err = new StringBuilder();
                err.AppendLine("При проверке целостности данных, произошли следующие ошибки:");
                foreach (var failure in result.Errors)
                {
                    var failed_property = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Single(a => a.Name == failure.PropertyName);

                    var display_att = failed_property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                    err.AppendLine($"- поле '{display_att?.Name ?? failure.PropertyName}': " + failure.ToString() + ".");
                }

                return err.ToString() + "\n";
            }
            return null;
        }

        private void Gridview_masts_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (XtraMessageBox.Show("Delete row(s)?", "Delete rows dialog", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            var deleted_mast = (e.Row as MastView);
            MastViewProvider.Delete(deleted_mast!);
#if DEBUG
            Debug.WriteLine("DELETE MAST UUID: " + deleted_mast!.UUID);
#endif
        }
        private void Gridview_masts_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var updated_mast = (e.Row as MastView);

            if (e.RowHandle == DataControlBase.NewItemRowHandle)
            {
                MastViewProvider.Insert(updated_mast!);

#if DEBUG
                Debug.WriteLine("INSERT MAST UUID: " + updated_mast!.UUID);
#endif
            }
            else
            {

                MastViewProvider.Update(updated_mast!);
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

            var deleted_protocol = (e.Row as ProtocolView);
            ProtocolViewProvider.Delete(deleted_protocol!);
#if DEBUG
            Debug.WriteLine("DELETE PROTOCOL UUID: " + deleted_protocol!.UUID);
#endif
        }
        private void Gridview_protocols_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var updated_protocol = (e.Row as ProtocolView);

            if (e.RowHandle == DataControlBase.NewItemRowHandle)
            {

                ProtocolViewProvider.Insert(updated_protocol!);
#if DEBUG
                Debug.WriteLine("INSERT PROTOCOL UUID: " + updated_protocol!.UUID);
#endif
            }
            else
            {

                ProtocolViewProvider.Update(updated_protocol!);
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

            var providers = typeof(Main).GetRuntimeFields()
                .Where(t => t.FieldType.IsAssignableToGeneric(typeof(IViewProvider<>)))
                .ToDictionary(a => a.FieldType.GenericTypeArguments[0]);

            foreach (var att in attributes)
            {
                var arg_type = att!.BindedTable ?? new object().GetType();
                var arg = providers.GetValueOrDefault(arg_type)?.GetValue(this);

                var binding_out = att.OnBindingFunction?.Invoke(arg);

                if (binding_out != null)
                    repository.Add(binding_out);
            }
        }
    }
}