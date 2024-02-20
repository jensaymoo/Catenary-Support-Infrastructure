using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.DTO;
using CatenarySupport.Providers.Views;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class MastTypeViewProvider : IViewProvider<MastTypeView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;
        static MastTypeViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<MastTypeView, MastTypeData>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public MastTypeViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastTypeView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            datacontext.Insert(mapper.Map<MastTypeData>(view));
        }

        public void Delete(MastTypeView view)
        {
            datacontext.Delete(mapper.Map<MastTypeData>(view));
        }
        public void Delete(Expression<Func<MastTypeView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<MastTypeData, bool>>>(predicate));
        }

        public IEnumerable<MastTypeView> Select()
        {
            return datacontext.Select<MastTypeData>()
                .Select(s => mapper.Map<MastTypeView>(s));
        }

        public IEnumerable<MastTypeView> Select(Expression<Func<MastTypeView, bool>> predicate)
        {
            return datacontext.Select<MastTypeData>(mapper.Map<Expression<Func<MastTypeData, bool>>>(predicate))
                .Select(s => mapper.Map<MastTypeView>(s));
        }

        public void Update(MastTypeView view)
        {
            datacontext.Update(mapper.Map<MastTypeData>(view));
        }
    }
}
