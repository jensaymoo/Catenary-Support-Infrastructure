using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using CatenarySupport.Database.Tables;
using CatenarySupport.Providers.View;
using CatenarySupport.Providers.Data;
using LinqToDB;
using LinqToDB.Extensions;
using LinqToDB.SqlQuery;
using System.Linq.Expressions;
using TableOptions = LinqToDB.TableOptions;
using System;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;
using System.Linq;

namespace CatenarySupport.Database
{
    internal class SQLite : IDatabase
    {


        static IMapper mapper;
        static readonly Dictionary<Type, Type> mapping_types = new Dictionary<Type, Type>();
        static MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddExpressionMapping();

            cfg.CreateProjection<MastData, MastTable>();
            cfg.CreateProjection<MastTable, MastData>();

            cfg.CreateProjection<MastTypeData, MastTypeTable>();
            cfg.CreateProjection<MastTypeTable, MastTypeData>();

            cfg.CreateProjection<PlantData, PlantTable>();
            cfg.CreateProjection<PlantTable, PlantData>();

            cfg.CreateProjection<DistrictData, DistrictTable>();
            cfg.CreateProjection<DistrictTable, DistrictData>();

            cfg.CreateProjection<ProtocolData, ProtocolTable>();
            cfg.CreateProjection<ProtocolTable, ProtocolData>();

            cfg.CreateProjection<MeasurmentData, MeasurmentTable>();
            cfg.CreateProjection<MeasurmentTable, MeasurmentData>();

            cfg.CreateProjection<DefectData, DefectTable>();
            cfg.CreateProjection<DefectTable, DefectData>();

            cfg.CreateMap<MastData, MastTable>().ReverseMap();
            cfg.CreateMap<MastTypeData, MastTypeTable>().ReverseMap();
            cfg.CreateMap<PlantData, PlantTable>().ReverseMap();
            cfg.CreateMap<DistrictData, DistrictTable>().ReverseMap();
            cfg.CreateMap<ProtocolData, ProtocolTable>().ReverseMap();
            cfg.CreateMap<MeasurmentData, MeasurmentTable>().ReverseMap();
            cfg.CreateMap<DefectData, DefectTable>().ReverseMap();

        });

        static SQLite()
        {
            mapping_types.AddTypeMapping(configuration, typeof(MastData), typeof(MastTable));
            mapping_types.AddTypeMapping(configuration, typeof(MastTable), typeof(MastData));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<MastData, bool>>), typeof(Expression<Func<MastTable, bool>>));

            mapping_types.AddTypeMapping(configuration, typeof(MastTypeData), typeof(MastTypeTable));
            mapping_types.AddTypeMapping(configuration, typeof(MastTypeTable), typeof(MastTypeData));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<MastTypeData, bool>>), typeof(Expression<Func<MastTypeTable, bool>>));

            mapping_types.AddTypeMapping(configuration, typeof(PlantData), typeof(PlantTable));
            mapping_types.AddTypeMapping(configuration, typeof(PlantTable), typeof(PlantData));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<PlantData, bool>>), typeof(Expression<Func<PlantTable, bool>>));

            mapping_types.AddTypeMapping(configuration, typeof(DistrictData), typeof(DistrictTable));
            mapping_types.AddTypeMapping(configuration, typeof(DistrictTable), typeof(DistrictData));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<DistrictData, bool>>), typeof(Expression<Func<DistrictTable, bool>>));

            mapping_types.AddTypeMapping(configuration, typeof(ProtocolData), typeof(ProtocolTable));
            mapping_types.AddTypeMapping(configuration, typeof(ProtocolTable), typeof(ProtocolData));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<ProtocolData, bool>>), typeof(Expression<Func<ProtocolTable, bool>>));

            mapping_types.AddTypeMapping(configuration, typeof(MeasurmentTable), typeof(MeasurmentData));
            mapping_types.AddTypeMapping(configuration, typeof(MeasurmentData), typeof(MeasurmentTable));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<MeasurmentData, bool>>), typeof(Expression<Func<MeasurmentTable, bool>>));

            mapping_types.AddTypeMapping(configuration, typeof(DefectTable), typeof(DefectData));
            mapping_types.AddTypeMapping(configuration, typeof(DefectData), typeof(DefectTable));
            mapping_types.AddTypeMapping(configuration, typeof(Expression<Func<DefectTable, bool>>), typeof(Expression<Func<DefectData, bool>>));





            mapper = configuration.CreateMapper();
        }

        DataContext context;
        public SQLite(IConfigurationProvider сonfigurationProvider)
        {
            context = new DataContext("SQLite", сonfigurationProvider.Configuration.ConnectionString!);
        }

        public void Delete<T>(T obj) where T : class, new()
        {
            var projected_type = MapperExtensions.ReplaceType(mapping_types, typeof(T));

            //create table if not exist
            var methtod_info = typeof(DataExtensions).GetMethods()
                .Where(m => m.Name == "CreateTable")
                .Single();
            var methtod_ref = methtod_info!.MakeGenericMethod(projected_type);

            var returned_data = methtod_ref.Invoke(this, new object[] { context, default(string)!, default(string)!, default(string)!, default(string)!,
                default(string)!, DefaultNullable.Null, default(string)!, TableOptions.CreateIfNotExists });

            //delete data
            methtod_info = typeof(DataExtensions).GetMethod("Delete"); ;
            methtod_ref = methtod_info!.MakeGenericMethod(projected_type);

            var table = mapper.Map(obj, typeof(T), projected_type);
            returned_data = methtod_ref.Invoke(this, new[] { context, table, default(string), default(string), default(string), default(string), default(TableOptions) });
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            throw new NotImplementedException();

            //context.GetTable<T>().Delete(expression);
        }

        public void Insert<T>(T obj) where T : class, new()
        {
            var projected_type = MapperExtensions.ReplaceType(mapping_types, typeof(T));

            //create table if not exist
            var methtod_info = typeof(DataExtensions).GetMethods()
                .Where(m => m.Name == "CreateTable")
                .Single();
            var methtod_ref = methtod_info!.MakeGenericMethod(projected_type);

            var returned_data = methtod_ref.Invoke(this, new object[] { context, default(string)!, default(string)!, default(string)!, default(string)!, 
                default(string)!, DefaultNullable.Null, default(string)!, TableOptions.CreateIfNotExists });

            //insert data
            methtod_info = typeof(DataExtensions).GetMethods()
                .Where(m => m.Name ==  "Insert" && m.GetParameters().Length == 7)
                .Single();
            methtod_ref = methtod_info!.MakeGenericMethod(projected_type);

            var table = mapper.Map(obj, typeof(T), projected_type);

            returned_data = methtod_ref.Invoke(this, new object[] { context, table, default(string)!, default(string)!, default(string)!, default(string)!, default(TableOptions) });
        }

        public IEnumerable<T> Select<T>() where T : class, new()
        {
            var projected_type = MapperExtensions.ReplaceType(mapping_types, typeof(T));

            //create table if not exist
            var methtod_info = typeof(DataExtensions).GetMethods()
                .Where(m => m.Name == "CreateTable")
                .Single();
            var methtod_ref = methtod_info!.MakeGenericMethod(projected_type);

            var returned_data = methtod_ref.Invoke(this, new object[] { context, default(string)!, default(string)!, default(string)!, default(string)!,
                default(string)!, DefaultNullable.Null, default(string)!, TableOptions.CreateIfNotExists });

            //select data
            methtod_info = typeof(DataExtensions).GetMethodEx("GetTable", typeof(DataContext));
            methtod_ref = methtod_info!.MakeGenericMethod(projected_type);
            returned_data = methtod_ref.Invoke(this, new[] { context });
            
            return (returned_data as IQueryable).ProjectTo<T>(configuration).ToArray<T>();
        }

        public IEnumerable<T> Select<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            var projected_type = MapperExtensions.ReplaceType(mapping_types, expression.GetType());
            var transaled_expr = mapper.MapExpression(expression, expression.GetType(), projected_type);
            var compiled_expr = transaled_expr.Compile();

            return Select<T>().Where(t => 
                (bool)compiled_expr.DynamicInvoke(mapper.Map(t, t.GetType(), MapperExtensions.ReplaceType(mapping_types, t.GetType())))!
            ).ToArray<T>();
        }

        public void Update<T>(T obj) where T : class, new()
        {
            var projected_type = MapperExtensions.ReplaceType(mapping_types, typeof(T));
            var methtod_info = typeof(DataExtensions).GetMethods()
                .Where(m => m.Name == "Update" && m.GetParameters().Length == 7)
                .Single();
            var methtod_ref = methtod_info!.MakeGenericMethod(projected_type);

            var table = mapper.Map(obj, typeof(T), projected_type);

            var returned_data = methtod_ref.Invoke(this, new object[] { context, table, default(string)!, default(string)!, default(string)!, default(string)!, default(TableOptions) });
        }

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}
