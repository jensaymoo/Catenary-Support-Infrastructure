﻿using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Providers.DTO;
using CatenarySupport.Providers.Views;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class PlantViewProvider : IViewProvider<PlantView>
    {
        private static readonly IMapper mapper;
        private readonly IDatabase datacontext;

        static PlantViewProvider()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<PlantView, PlantData>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public PlantViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(PlantView view)
        {
            view.UUID = Guid.NewGuid().ToString();
            datacontext.Insert(mapper.Map<PlantData>(view));
            //datacontext.Insert(model);
        }

        public void Delete(PlantView view)
        {
            datacontext.Delete(mapper.Map<PlantData>(view));
            //datacontext.Delete(model);
        }
        public void Delete(Expression<Func<PlantView, bool>> predicate)
        {
            datacontext.Delete(mapper.Map<Expression<Func<PlantData, bool>>>(predicate));
            //datacontext.Delete(predicate);
        }

        public IEnumerable<PlantView> Select()
        {
            return datacontext.Select<PlantData>()
                .Select(s => mapper.Map<PlantView>(s));
            //return datacontext.Select<PlantView>();
        }

        public IEnumerable<PlantView> Select(Expression<Func<PlantView, bool>> predicate)
        {
            return datacontext.Select<PlantData>(mapper.Map<Expression<Func<PlantData, bool>>>(predicate))
                .Select(s => mapper.Map<PlantView>(s)); 
            //return datacontext.Select<PlantView>(predicate);
        }

        public void Update(PlantView view)
        {
            datacontext.Update(mapper.Map<PlantData>(view));
            //datacontext.Update(model);
        }
    }
}
