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
                //cfg.CreateMap<ProtocolData, DefectData>();

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

            var measurments = defects.SelectMany(defect => datacontext.Select<MeasurmentData>(measurment => measurment.UUID == defect.MeasurmentUUID))
                .DistinctBy(measurment => measurment.UUID);

            var protocols = measurments.SelectMany(measurment => datacontext.Select<ProtocolData>(protocol => protocol.UUID == measurment.ProtocolUUID))
                .DistinctBy(protocol => protocol.UUID);

            return defects.Select(defect => new DefectView()
            {
                UUID = defect.UUID!,
                MeasurmentUUID = defect.MeasurmentUUID!,
                MastUUID = measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.MastUUID!,
                ProtocolUUID = protocols.SingleOrDefault(p => p.UUID == measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.ProtocolUUID)?.UUID!,
                ProtocolID = protocols.SingleOrDefault(p => p.UUID == measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.ProtocolUUID)?.ProtocolID,
                ProtocolDate = protocols.SingleOrDefault(p => p.UUID == measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.ProtocolUUID)?.ProtocolDate,
                Defect = defect.Defect,
                Description = defect.Description,
                Photo = defect.Photo
            });
        }

        public IEnumerable<DefectView> Select(Expression<Func<DefectView, bool>> predicate)
        {
            var defects = datacontext.Select<DefectData>(mapper.Map<Expression<Func<DefectData, bool>>>(predicate));

            var measurments = defects.SelectMany(defect => datacontext.Select<MeasurmentData>(measurment => measurment.UUID == defect.MeasurmentUUID))
                .DistinctBy(measurment => measurment.UUID);

            var protocols = measurments.SelectMany(measurment => datacontext.Select<ProtocolData>(protocol => protocol.UUID == measurment.ProtocolUUID))
                .DistinctBy(protocol => protocol.UUID);

            return defects.Select(defect => new DefectView()
            {
                UUID = defect.UUID!,
                MeasurmentUUID = defect.MeasurmentUUID!,
                MastUUID = measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.MastUUID!,
                ProtocolUUID = protocols.SingleOrDefault(p => p.UUID == measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.ProtocolUUID)?.UUID!,
                ProtocolID = protocols.SingleOrDefault(p => p.UUID == measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.ProtocolUUID)?.ProtocolID,
                ProtocolDate = protocols.SingleOrDefault(p => p.UUID == measurments.SingleOrDefault(m => m.UUID == defect.MeasurmentUUID)?.ProtocolUUID)?.ProtocolDate,
                Defect = defect.Defect,
                Description = defect.Description,
                Photo = defect.Photo
            }); 
        }

        public void Update(DefectView view)
        {
            datacontext.Update(mapper.Map<DefectData>(view));
        }
    }
}
