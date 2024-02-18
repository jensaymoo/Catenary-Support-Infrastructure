using CatenarySupport.Database;
using CatenarySupport.Providers.Objects;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class ProtocolProvider : IProvider<ProtocolObject>
    {
        private readonly IDatabase database;
        public ProtocolProvider(IDatabase db)
        {
            database = db;
        }

        public void Insert(ProtocolObject model)
        {
            database.Insert(model);
        }

        public void Delete(ProtocolObject model)
        {
            database.Delete(model);
        }
        public void Delete(Expression<Func<ProtocolObject, bool>> predicate)
        {
            database.Delete(predicate);
        }

        public IEnumerable<ProtocolObject> Select()
        {
            
            return database.Select<ProtocolObject>();
        }

        public IEnumerable<ProtocolObject> Select(Expression<Func<ProtocolObject, bool>> predicate)
        {
            return database.Select(predicate);
        }

        public void Update(ProtocolObject model)
        {
            database.Update(model);
        }


    }
}
