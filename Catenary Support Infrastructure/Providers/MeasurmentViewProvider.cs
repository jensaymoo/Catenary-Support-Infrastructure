using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.Data;
using CatenarySupport.Providers.View;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class MeasurmentViewProvider : IViewProvider<MeasurmentView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;

        static MeasurmentViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<MeasurmentView, MeasurmentData>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public MeasurmentViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MeasurmentView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            datacontext.Insert(mapper.Map<MeasurmentData>(view));
        }

        public void Delete(MeasurmentView view)
        {
            datacontext.Delete(mapper.Map<PlantData>(view));
        }
        public void Delete(Expression<Func<MeasurmentView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<PlantData, bool>>>(predicate));
        }

        public IEnumerable<MeasurmentView> Select()
        {
            return datacontext.Select<MeasurmentData>()
                .Select(s => mapper.Map<MeasurmentView>(s));
        }

        public IEnumerable<MeasurmentView> Select(Expression<Func<MeasurmentView, bool>> predicate)
        {
            return datacontext.Select<MeasurmentData>(mapper.Map<Expression<Func<MeasurmentData, bool>>>(predicate))
                .Select(s => mapper.Map<MeasurmentView>(s)); 
        }

        public void Update(MeasurmentView view)
        {
            datacontext.Update(mapper.Map<PlantData>(view));
        }
    }
}
