using CatenarySupport.Providers;
using DevExpress.XtraEditors.Repository;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CatenarySupport.Attributes
{
    public class BindedGridColumnAttribute: BaseColumnAttribute
    {
        public BindedGridColumnAttribute(Type binded_table, [CallerMemberName]string? binded_member = null)
        {
            if (binded_member is null) throw new ArgumentNullException(nameof(binded_member));

            BindedMember = binded_member;
            BindedTable = binded_table;

            OnBindingFunction = (provider) =>
            {
                if (provider is null) throw new ArgumentNullException(nameof(provider));

                var acessor = new MemberAcessor<object>();
                if (acessor.TryCallMethodWithoutParams(provider, "Select", out var values))
                {
                    var binded_val = new BindingSource();
                    binded_val.AddCollection(values as IEnumerable<object>);

                    if (binded_val.Count > 0)
                    {
                        var repo_item = new RepositoryItemGridLookUpEdit()
                        {
                            Name = BindedMember,
                            DisplayMember = BindedMember,
                            ValueMember = BindedMember,
                            DataSource = binded_val,
                            ShowPopupShadow = true,
                            BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup,
                            AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True,
                            //PopupFormMinSize = new Size(1280, 480),
                        };
                        repo_item.View.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True; 
                        repo_item.View.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                        return repo_item;
                    }
                }
                return null;
            };
        }
    }
}
