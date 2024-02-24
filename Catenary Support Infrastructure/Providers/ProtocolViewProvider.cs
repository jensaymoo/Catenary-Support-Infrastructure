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
            return datacontext.Select<ProtocolData>()
                .Select(s => mapper.Map<ProtocolView>(s));
        }

        public IEnumerable<ProtocolView> Select(Expression<Func<ProtocolView, bool>> predicate)
        {
            return datacontext.Select<ProtocolData>(mapper.Map<Expression<Func<ProtocolData, bool>>>(predicate))
                .Select(s => mapper.Map<ProtocolView>(s));
        }

        public void Update(ProtocolView view)
        {
            view.ProtocolDate = DateTime.Parse(view.ProtocolDate).ToString("dd.MM.yyyy");
            datacontext.Update(mapper.Map<ProtocolData>(view));
        }
    }
}
