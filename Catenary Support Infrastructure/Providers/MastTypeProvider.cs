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
    internal class MastTypeProvider : IProvider<MastTypeData>
    {
        private readonly IDatabase datacontext;
        public MastTypeProvider(IDatabase db)
        {
            datacontext = db;
            //datacontext.CreateTable<MastTypeData>(tableOptions: TableOptions.CreateIfNotExists);
        }

        public void Insert(MastTypeData model)
        {
            datacontext.Insert(model);
        }

        public void Delete(MastTypeData model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastTypeData, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<MastTypeData> Select()
        {
            return datacontext.Select<MastTypeData>();
        }

        public IEnumerable<MastTypeData> Get(Expression<Func<MastTypeData, bool>> predicate)
        {
            return datacontext.Select<MastTypeData>(predicate);
        }

        public void Update(MastTypeData model)
        {
            datacontext.Update(model);
        }
    }
}
