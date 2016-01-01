using System;
using System.IO;
using System.Reflection;
using DataAccess.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

// Ref.: http://trycatchfail.com/blog/post/Getting-Started-with-NHibernate-3-and-SQL-Compact.aspx
// Ref.: http://www.jagregory.com/writings/fluent-nhibernate-auto-mapping-and-base-classes/

namespace DataAccess
{
    public static class NHibernateBootstrapper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        public static void Bootstrap(string connectionString = null)
        {
            _configuration = Fluently.Configure()
                //.Database(MsSqlCeConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("MyConnectionString")))
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(connectionString ?? GetConnectionString()))
                .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<MountainMap>()
                    .Conventions.AddFromAssemblyOf<MountainMap>()
                )
                .ExposeConfiguration(cfg => cfg.SetProperty("connection.release_mode", "on_close"))
                .BuildConfiguration();

            _sessionFactory = _configuration.BuildSessionFactory();
        }

        private static string GetConnectionString()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return "Data Source=" + Path.GetDirectoryName(path) + @"\ScotlandsMountains.sdf";
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
