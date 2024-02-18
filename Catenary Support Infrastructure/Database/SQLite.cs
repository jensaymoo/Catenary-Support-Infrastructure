using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using CatenarySupport.Database.Tables;
using CatenarySupport.Providers.Objects;
using LinqToDB;
using LinqToDB.Extensions;
using LinqToDB.SqlQuery;
using System.Linq.Expressions;
using TableOptions = LinqToDB.TableOptions;

namespace CatenarySupport.Database
{
    internal class SQLite : IDatabase
    {


        static IMapper mapper;
        static readonly Dictionary<Type, Type> mapping_types = new Dictionary<Type, Type>();
        static MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddExpressionMapping();

            cfg.CreateProjection<MastObject, MastTable>();
            cfg.CreateProjection<MastTable, MastObject>();

            cfg.CreateProjection<MastTypeObject, MastTypeTable>();
            cfg.CreateProjection<MastTypeTable, MastTypeObject>();

            cfg.CreateProjection<PlantObject, PlantTable>();
            cfg.CreateProjection<PlantTable, PlantObject>();

            cfg.CreateProjection<DistrictObject, DistrictTable>();
            cfg.CreateProjection<DistrictTable, DistrictObject>();

            cfg.CreateProjection<ProtocolObject, ProtocolTable>();
            cfg.CreateProjection<ProtocolTable, ProtocolObject>();


            cfg.CreateMap<MastObject, MastTable>().ReverseMap();
            cfg.CreateMap<MastTypeObject, MastTypeTable>().ReverseMap();
            cfg.CreateMap<PlantObject, PlantTable>().ReverseMap();
            cfg.CreateMap<DistrictObject, DistrictTable>().ReverseMap();
            cfg.CreateMap<ProtocolObject, ProtocolTable>().ReverseMap();

        });

        static SQLite()
        {
            mapping_types.AddTypeMapping(configuration, typeof(MastObject), typeof(MastTable));
            mapping_types.AddTypeMapping(configuration, typeof(MastTable), typeof(MastObject));

            mapping_types.AddTypeMapping(configuration, typeof(MastTypeObject), typeof(MastTypeTable));
            mapping_types.AddTypeMapping(configuration, typeof(MastTypeTable), typeof(MastTypeObject));

            mapping_types.AddTypeMapping(configuration, typeof(PlantObject), typeof(PlantTable));
            mapping_types.AddTypeMapping(configuration, typeof(PlantTable), typeof(PlantObject));

            mapping_types.AddTypeMapping(configuration, typeof(DistrictObject), typeof(DistrictTable));
            mapping_types.AddTypeMapping(configuration, typeof(DistrictTable), typeof(DistrictObject));

            mapping_types.AddTypeMapping(configuration, typeof(ProtocolObject), typeof(ProtocolTable));
            mapping_types.AddTypeMapping(configuration, typeof(ProtocolTable), typeof(ProtocolObject));

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
            
            return (returned_data as IQueryable).ProjectTo<T>(configuration);
        }

        public IEnumerable<T> Select<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            throw new NotImplementedException();

            //return context.GetTable<T>().Where(expression);
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
