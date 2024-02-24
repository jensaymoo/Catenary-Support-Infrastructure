using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.Data;
using CatenarySupport.Providers.View;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class DistrictViewProvider : IViewProvider<DistrictView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;

        static DistrictViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<DistrictView, DistrictData>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public DistrictViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(DistrictView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            datacontext.Insert(mapper.Map<DistrictData>(view));
        }

        public void Delete(DistrictView view)
        {
            datacontext.Delete(mapper.Map<DistrictData>(view));
        }
        public void Delete(Expression<Func<DistrictView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<DistrictData, bool>>>(predicate));
        }

        public IEnumerable<DistrictView> Select()
        {
            return datacontext.Select<DistrictData>()
                .Select(s => mapper.Map<DistrictView>(s));
        }

        public IEnumerable<DistrictView> Select(Expression<Func<DistrictView, bool>> predicate)
        {
            return datacontext.Select<DistrictData>(mapper.Map<Expression<Func<DistrictData, bool>>>(predicate))
                .Select(s => mapper.Map<DistrictView>(s));
        }

        public void Update(DistrictView view)
        {
            datacontext.Update(mapper.Map<DistrictData>(view));
        }
    }
}
