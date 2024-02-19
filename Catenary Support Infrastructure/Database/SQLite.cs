using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using CatenarySupport.Database.Tables;
using CatenarySupport.Providers.Views;
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

            cfg.CreateProjection<MastView, MastTable>();
            cfg.CreateProjection<MastTable, MastView>();

            cfg.CreateProjection<MastTypeView, MastTypeTable>();
            cfg.CreateProjection<MastTypeTable, MastTypeView>();

            cfg.CreateProjection<PlantView, PlantTable>();
            cfg.CreateProjection<PlantTable, PlantView>();

            cfg.CreateProjection<DistrictView, DistrictTable>();
            cfg.CreateProjection<DistrictTable, DistrictView>();

            cfg.CreateProjection<ProtocolView, ProtocolTable>();
            cfg.CreateProjection<ProtocolTable, ProtocolView>();


            cfg.CreateMap<MastView, MastTable>().ReverseMap();
            cfg.CreateMap<MastTypeView, MastTypeTable>().ReverseMap();
            cfg.CreateMap<PlantView, PlantTable>().ReverseMap();
            cfg.CreateMap<DistrictView, DistrictTable>().ReverseMap();
            cfg.CreateMap<ProtocolView, ProtocolTable>().ReverseMap();

        });

        static SQLite()
        {
            mapping_types.AddTypeMapping(configuration, typeof(MastView), typeof(MastTable));
            mapping_types.AddTypeMapping(configuration, typeof(MastTable), typeof(MastView));

            mapping_types.AddTypeMapping(configuration, typeof(MastTypeView), typeof(MastTypeTable));
            mapping_types.AddTypeMapping(configuration, typeof(MastTypeTable), typeof(MastTypeView));

            mapping_types.AddTypeMapping(configuration, typeof(PlantView), typeof(PlantTable));
            mapping_types.AddTypeMapping(configuration, typeof(PlantTable), typeof(PlantView));

            mapping_types.AddTypeMapping(configuration, typeof(DistrictView), typeof(DistrictTable));
            mapping_types.AddTypeMapping(configuration, typeof(DistrictTable), typeof(DistrictView));

            mapping_types.AddTypeMapping(configuration, typeof(ProtocolView), typeof(ProtocolTable));
            mapping_types.AddTypeMapping(configuration, typeof(ProtocolTable), typeof(ProtocolView));

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
