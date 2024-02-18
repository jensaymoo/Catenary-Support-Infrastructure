using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{

    internal class MastProvider : IProvider<MastObject>
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

        public MastProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastObject model)
        {
            model.UUID = Guid.NewGuid().ToString();
            //datacontext.Insert(mapper.Map<MastTable>(model));
            datacontext.Insert(model);
        }

        public void Delete(MastObject model)
        {
            //datacontext.Delete(mapper.Map<MastTable>(model));
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastObject, bool>> predicate)
        {
            datacontext.Delete(predicate);
            //datacontext.Delete(mapper.Map<Expression<Func<MastTable, bool>>>(predicate));
        }

        public IEnumerable<MastObject> Select()
        {
            return datacontext.Select<MastObject>();
            //return datacontext.Select<MastTable>()
            //    .Select(s => mapper.Map<MastObject>(s));
        }

        public IEnumerable<MastObject> Select(Expression<Func<MastObject, bool>> predicate)
        {
            return datacontext.Select<MastObject>(predicate);
            //return datacontext.Select<MastTable>(mapper.Map<Expression<Func<MastTable, bool>>>(predicate))
            //    .Select(s => mapper.Map<MastObject>(s));
        }

        public void Update(MastObject model)
        {
            datacontext.Update(model);
           //datacontext.Update(mapper.Map<MastTable>(model));
        }
    }
}
