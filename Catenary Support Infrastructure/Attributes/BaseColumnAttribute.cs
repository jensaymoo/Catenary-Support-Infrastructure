using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport.Attributes
{
    public abstract class BaseColumnAttribute : Attribute
    {
        public string? BindedMember { get; protected set; } = null;
        public Type? BindedTable { get; protected set; } = null;
        public Func<object?, RepositoryItem>? OnBindingFunction { get; protected set; } = null;
    }
}
