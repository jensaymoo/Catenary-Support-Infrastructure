using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport
{
    internal static class Extensions
    {
        public static void RunInTransaction(this DataContext context, Action action)
        {
            var transaction = context.BeginTransaction();

            action();

            transaction.CommitTransaction();
        }
    }
}
