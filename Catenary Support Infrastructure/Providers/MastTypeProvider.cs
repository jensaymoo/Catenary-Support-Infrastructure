using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport.Providers
{
    internal class MastTypeProvider : IProvider<MastTypeObject>
    {
        private readonly IDatabase datacontext;
        public MastTypeProvider(IDatabase db)
        {
            datacontext = db;
            //datacontext.CreateTable<MastTypeData>(tableOptions: TableOptions.CreateIfNotExists);
        }

        public void Insert(MastTypeObject model)
        {
            datacontext.Insert(model);
        }

        public void Delete(MastTypeObject model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastTypeObject, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<MastTypeObject> Select()
        {
            return datacontext.Select<MastTypeObject>();
        }

        public IEnumerable<MastTypeObject> Select(Expression<Func<MastTypeObject, bool>> predicate)
        {
            return datacontext.Select<MastTypeObject>(predicate);
        }

        public void Update(MastTypeObject model)
        {
            datacontext.Update(model);
        }
    }
}
