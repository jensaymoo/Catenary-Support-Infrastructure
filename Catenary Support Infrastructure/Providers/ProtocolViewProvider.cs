using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.Data;
using CatenarySupport.Providers.View;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class ProtocolViewProvider : IViewProvider<ProtocolView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;
        static ProtocolViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<ProtocolView, ProtocolData>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public ProtocolViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(ProtocolView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            view.ProtocolDate = DateTime.Parse(view.ProtocolDate).ToString("dd.MM.yyyy");
            datacontext.Insert(mapper.Map<ProtocolData>(view));
        }

        public void Delete(ProtocolView view)
        {
            datacontext.Delete(mapper.Map<ProtocolData>(view));
        }
        public void Delete(Expression<Func<ProtocolView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<ProtocolData, bool>>>(predicate));
        }

        public IEnumerable<ProtocolView> Select()
        {
            var protocols = datacontext.Select<ProtocolData>();
            var plants = protocols.SelectMany(protocol => datacontext.Select<PlantData>(plant => plant.UUID == protocol.PlantUUID))
                .DistinctBy(plant => plant.UUID);

            var districts = protocols.SelectMany(protocol => datacontext.Select<DistrictData>(district => district.UUID == protocol.DistrictUUID))
                .DistinctBy(district => district.UUID);

            return protocols.Select(s => new Func<ProtocolData, ProtocolView>((s) =>
            {
                var view = mapper.Map<ProtocolView>(s);

                view.Plant = plants.SingleOrDefault(plant => plant.UUID == s.PlantUUID)?.Plant;
                view.District = districts.SingleOrDefault(district => district.UUID == s.DistrictUUID)?.District;

                return view;
            }).Invoke(s));

            //return datacontext.Select<ProtocolData>()
            //    .Select(s => mapper.Map<ProtocolView>(s));
        }

        public IEnumerable<ProtocolView> Select(Expression<Func<ProtocolView, bool>> predicate)
        {
            var protocols = datacontext.Select<ProtocolData>(mapper.Map<Expression<Func<ProtocolData, bool>>>(predicate));
            var plants = protocols.SelectMany(protocol => datacontext.Select<PlantData>(plant => plant.UUID == protocol.PlantUUID))
                .DistinctBy(plant => plant.UUID);

            var districts = protocols.SelectMany(protocol => datacontext.Select<DistrictData>(district => district.UUID == protocol.DistrictUUID))
                .DistinctBy(district => district.UUID);

            return protocols.Select(s => new Func<ProtocolData, ProtocolView>((s) =>
            {
                var view = mapper.Map<ProtocolView>(s);

                view.Plant = plants.SingleOrDefault(plant => plant.UUID == s.PlantUUID)?.Plant;
                view.District = districts.SingleOrDefault(district => district.UUID == s.DistrictUUID)?.District;

                return view;
            }).Invoke(s));

            //return protocols
            //   .Select(s => mapper.Map<ProtocolView>(s));
        }

        public void Update(ProtocolView view)
        {
            view.ProtocolDate = DateTime.Parse(view.ProtocolDate).ToString("dd.MM.yyyy");
            datacontext.Update(mapper.Map<ProtocolData>(view));
        }
    }
}
