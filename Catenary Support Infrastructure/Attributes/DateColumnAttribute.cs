using DevExpress.XtraEditors.Mask.Design;
using DevExpress.XtraEditors.Repository;
using System.Runtime.CompilerServices;

namespace CatenarySupport.Attributes
{
    public class DateColumnAttribute: BaseColumnAttribute
    {
        public DateColumnAttribute([CallerMemberName] string? bindedMember = null)
        {
            if (bindedMember is null) throw new ArgumentNullException(nameof(bindedMember));

            BindedMember = bindedMember;

            OnBindingFunction = (provider) =>
            {
                var repo_item = new RepositoryItemDateEdit()
                {
                    Name = BindedMember,
                };
                return repo_item;
            };
        }
    }
}
