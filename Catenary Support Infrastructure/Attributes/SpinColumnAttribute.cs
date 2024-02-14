using DevExpress.XtraEditors.Repository;
using System.Runtime.CompilerServices;

namespace CatenarySupport.Attributes
{
    public class SpinColumnAttribute: BaseColumnAttribute
    {
        public int MaxValue { get; protected set; }
        public int MinValue { get; protected set; }
        public SpinColumnAttribute(int minValue = 0, int maxValue = 10, [CallerMemberName] string? bindedMember = null)
        {
            if (bindedMember is null) throw new ArgumentNullException(nameof(bindedMember));

            BindedMember = bindedMember;
            MinValue = minValue;
            MaxValue = maxValue;

            OnBindingFunction = (provider) =>
            {
                var repo_item = new RepositoryItemSpinEdit()
                {
                    Name = BindedMember,
                    UseMaskAsDisplayFormat = true,
                    EditMask = "n0",
                    MaxValue = MaxValue,
                    MinValue = MinValue
                };

                return repo_item;
            };
        }
    }
}
