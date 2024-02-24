using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.Data;
using CatenarySupport.Providers.View;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class DefectViewProvider : IViewProvider<DefectView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;

        static DefectViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<DefectView, DefectData>()
                    .ReverseMap();
                cfg.CreateMap<ProtocolData, DefectData>();

            }).CreateMapper();
        }

        public DefectViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(DefectView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            datacontext.Insert(mapper.Map<DefectData>(view));
        }

        public void Delete(DefectView view)
        {
            datacontext.Delete(mapper.Map<DefectData>(view));
        }
        public void Delete(Expression<Func<DefectView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<DefectData, bool>>>(predicate));
        }

        public IEnumerable<DefectView> Select()
        {
            var defects = datacontext.Select<DefectData>();
            var protocols = defects.SelectMany(d => datacontext.Select<ProtocolData>(s => s.UUID == d.ProtocolUUID))
                .DistinctBy(sd=> sd.UUID);

            return defects
                .Join(protocols, d => d.ProtocolUUID, p => p.UUID, (d, p) => new DefectView()
                {
                    UUID = d.UUID!,
                    MastUUID = d.MastUUID!,
                    ProtocolUUID = d.ProtocolUUID!,
                    ProtocolID = p.ProtocolID,
                    ProtocolDate = p.ProtocolDate,
                    Defect = d.Defect,
                    Description = d.Description,
                    Photo = d.Photo
                });

            //return datacontext.Select<DefectData>()
            //    .Select(s => mapper.Map<DefectView>(s));
        }

        public IEnumerable<DefectView> Select(Expression<Func<DefectView, bool>> predicate)
        {
            var defects = datacontext.Select<DefectData>(mapper.Map<Expression<Func<DefectData, bool>>>(predicate));
            var protocols = defects.SelectMany(d => datacontext.Select<ProtocolData>(s => s.UUID == d.ProtocolUUID))
                .DistinctBy(sd => sd.UUID);

            return defects
                .Join(protocols, d => d.ProtocolUUID, p => p.UUID, (d, p) => new DefectView()
                {
                    UUID = d.UUID!,
                    MastUUID = d.MastUUID!,
                    ProtocolUUID = d.ProtocolUUID!,
                    ProtocolID = p.ProtocolID,
                    ProtocolDate = p.ProtocolDate,
                    Defect = d.Defect,
                    Description = d.Description,
                    Photo = d.Photo
                });


            //return datacontext.Select<DefectData>(mapper.Map<Expression<Func<DefectData, bool>>>(predicate))
            //    .Select(s => mapper.Map<DefectView>(s));
        }

        public void Update(DefectView view)
        {
            datacontext.Update(mapper.Map<DefectData>(view));
        }
    }
}
