using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.View;
using CatenarySupport.Providers.Data;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{

    internal class MastViewProvider : IViewProvider<MastView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;

        static MastViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<MastView, MastData>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public MastViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            datacontext.Insert(mapper.Map<MastData>(view));
        }

        public void Delete(MastView view)
        {
            datacontext.Delete(mapper.Map<MastData>(view));
        }
        public void Delete(Expression<Func<MastView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<MastData, bool>>>(predicate));
        }

        public IEnumerable<MastView> Select()
        {
            return datacontext.Select<MastData>()
                .Select(s => mapper.Map<MastView>(s));
        }

        public IEnumerable<MastView> Select(Expression<Func<MastView, bool>> predicate)
        {
            return datacontext.Select<MastData>(mapper.Map<Expression<Func<MastData, bool>>>(predicate))
                .Select(s => mapper.Map<MastView>(s));
        }

        public void Update(MastView view)
        {
            datacontext.Update(mapper.Map<MastData>(view));
        }
    }
}
