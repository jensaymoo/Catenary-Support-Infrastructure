using CatenarySupport.Database;
using CatenarySupport.Providers.Views;
using FluentValidation;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class ProtocolViewProvider : IProvider<ProtocolView>
    {
        private readonly IDatabase database;
        public ProtocolViewProvider(IDatabase db)
        {
            database = db;
        }

        public void Insert(ProtocolView model)
        {
            model.ProtocolDate = DateTime.Parse(model.ProtocolDate).ToString("dd.MM.yyyy");
            database.Insert(model);
        }

        public void Delete(ProtocolView model)
        {
            database.Delete(model);
        }
        public void Delete(Expression<Func<ProtocolView, bool>> predicate)
        {
            database.Delete(predicate);
        }

        public IEnumerable<ProtocolView> Select()
        {
            
            return database.Select<ProtocolView>();
        }

        public IEnumerable<ProtocolView> Select(Expression<Func<ProtocolView, bool>> predicate)
        {
            return database.Select(predicate);
        }

        public void Update(ProtocolView model)
        {
            model.ProtocolDate = DateTime.Parse(model.ProtocolDate).ToString("dd.MM.yyyy");
            database.Update(model);
        }


    }
}
