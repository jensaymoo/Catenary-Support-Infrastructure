using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using DevExpress.Data.Browsing;
using DevExpress.XtraReports.Native.Data;
using LinqToDB;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class MastProvider : IProvider<MastData>
    {
        private readonly IDatabase datacontext;
        public MastProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastData model)
        {
            datacontext.Insert(model);
        }

        public void Delete(MastData model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastData, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<MastData> Select()
        {
            return datacontext.Select<MastData>();
        }

        public IEnumerable<MastData> Get(Expression<Func<MastData, bool>> predicate)
        {
            return datacontext.Select<MastData>(predicate);
        }

        public void Update(MastData model)
        {
           datacontext.Update(model);
        }
    }
}
