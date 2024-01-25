using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using LinqToDB;

namespace CatenarySupport.Providers
{
    internal class PillarsProvider : IProvider<PillarData>
    {
        private readonly IDataContext datacontext;
        public PillarsProvider(IDataContext db)
        {
            datacontext = db;

            datacontext.CreateTable<PillarData>(tableOptions: TableOptions.CreateIfNotExists);
        }

        public void Add(PillarData model)
        {
            datacontext.Insert(model);
        }

        public void Delete(PillarData model)
        {
            datacontext.Delete(model);
        }

        public IEnumerable<PillarData> Get()
        {
            return datacontext.GetTable<PillarData>()
                .AsEnumerable();
        }

        public IEnumerable<PillarData> Get(Func<PillarData, bool> predicate)
        {
            return datacontext.GetTable<PillarData>()
                .Where(predicate);
        }

        public void Update(PillarData model)
        {
            datacontext.Update(model);
        }
    }
}
