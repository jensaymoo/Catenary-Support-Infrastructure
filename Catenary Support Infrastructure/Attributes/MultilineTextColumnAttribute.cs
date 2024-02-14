using CatenarySupport.Providers;
using DevExpress.XtraEditors.Repository;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CatenarySupport.Attributes
{
    public class MultilineTextColumnAttribute: BaseColumnAttribute
    {
        public MultilineTextColumnAttribute([CallerMemberName] string? binded_member = null)
        {
            if (binded_member is null) throw new ArgumentNullException(nameof(binded_member));

            BindedMember = binded_member;

            OnBindingFunction = (provider) =>
            {
                var repo_item = new RepositoryItemMemoEdit()
                {
                    Name = BindedMember,
                };

                return repo_item;
            };
        }
    }
}
