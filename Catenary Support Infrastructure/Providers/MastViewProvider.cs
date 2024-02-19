using CatenarySupport.Database;
using CatenarySupport.Providers.Views;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{

    internal class MastViewProvider : IProviderView<MastView>
    {
        //private static readonly IMapper mapper;
        private readonly IDatabase datacontext;

        //static MastProvider()
        //{
        //    mapper = new MapperConfiguration(cfg => {

        //        cfg.AddExpressionMapping();

        //        cfg.CreateMap<MastTable, MastObject>()
        //            .ReverseMap();
        //    }).CreateMapper();
        //}

        public MastViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastView model)
        {
            model.UUID = Guid.NewGuid().ToString();
            //datacontext.Insert(mapper.Map<MastTable>(model));
            datacontext.Insert(model);
        }

        public void Delete(MastView model)
        {
            //datacontext.Delete(mapper.Map<MastTable>(model));
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastView, bool>> predicate)
        {
            datacontext.Delete(predicate);
            //datacontext.Delete(mapper.Map<Expression<Func<MastTable, bool>>>(predicate));
        }

        public IEnumerable<MastView> Select()
        {
            return datacontext.Select<MastView>();
            //return datacontext.Select<MastTable>()
            //    .Select(s => mapper.Map<MastObject>(s));
        }

        public IEnumerable<MastView> Select(Expression<Func<MastView, bool>> predicate)
        {
            return datacontext.Select<MastView>(predicate);
            //return datacontext.Select<MastTable>(mapper.Map<Expression<Func<MastTable, bool>>>(predicate))
            //    .Select(s => mapper.Map<MastObject>(s));
        }

        public void Update(MastView model)
        {
            datacontext.Update(model);
           //datacontext.Update(mapper.Map<MastTable>(model));
        }
    }
}
