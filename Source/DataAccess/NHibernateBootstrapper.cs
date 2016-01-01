using ScotlandsMountains.DataAccess.AuxiliaryDatabaseObjects;
using ScotlandsMountains.DataAccess.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

// Ref.: http://www.jagregory.com/writings/fluent-nhibernate-auto-mapping-and-base-classes/

namespace ScotlandsMountains.DataAccess
{
    public static class NHibernateBootstrapper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        public static void Bootstrap()
        {
            _configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c =>c.FromConnectionStringWithKey("ScotlandsMountains")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MountainMap>().Conventions.AddFromAssemblyOf<MountainMap>())
                .BuildConfiguration();
            _configuration.AddAuxiliaryDatabaseObject(new MapToMountainPk());
            _configuration.AddAuxiliaryDatabaseObject(new MountainsToTablePk());
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        public static void UpdateSchema()
        {
            new SchemaUpdate(_configuration).Execute(false, true);
        }

        public static void CreateSchema()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
        }

        public static ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
