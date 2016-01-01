using System;
using System.Collections.Generic;
using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Metadata;
using NHibernate.Stat;
using NHibernate.Tool.hbm2ddl;
using ScotlandsMountains.Data.Mappings;

namespace ScotlandsMountains.Data
{
    public sealed class SessionFactory : ISessionFactory
    {
        private static volatile SessionFactory _instance;
        private static readonly object SyncRoot = new Object();
        private readonly ISessionFactory _sessionFactory;

        private SessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("ScotlandsMountains")))
                .Mappings(x => x
                    .FluentMappings.AddFromAssemblyOf<MountainMap>()
                    .Conventions.AddFromAssemblyOf<MountainMap>()
                )
                //.ExposeConfiguration(CreateSchema)
                .BuildSessionFactory();
        }

        private void CreateSchema(Configuration config)
        {
            new SchemaExport(config).Drop(false, true);
            new SchemaExport(config).Create(false, true);
        }

        public static SessionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new SessionFactory();
                    }
                }

                return _instance;
            }
        }

        public void Dispose()
        {
            _sessionFactory.Dispose();
        }

        public ISession OpenSession(IDbConnection conn)
        {
            return _sessionFactory.OpenSession(conn);
        }

        public ISession OpenSession(IInterceptor sessionLocalInterceptor)
        {
            return _sessionFactory.OpenSession(sessionLocalInterceptor);
        }

        public ISession OpenSession(IDbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            return _sessionFactory.OpenSession(conn, sessionLocalInterceptor);
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        public IClassMetadata GetClassMetadata(Type persistentClass)
        {
            return _sessionFactory.GetClassMetadata(persistentClass);
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            return _sessionFactory.GetClassMetadata(entityName);
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            return _sessionFactory.GetCollectionMetadata(roleName);
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            return _sessionFactory.GetAllClassMetadata();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            return _sessionFactory.GetAllCollectionMetadata();
        }

        public void Close()
        {
            _sessionFactory.Close();
        }

        public void Evict(Type persistentClass)
        {
            _sessionFactory.Evict(persistentClass);
        }

        public void Evict(Type persistentClass, object id)
        {
            _sessionFactory.Evict(persistentClass, id);
        }

        public void EvictEntity(string entityName)
        {
            _sessionFactory.EvictEntity(entityName);
        }

        public void EvictEntity(string entityName, object id)
        {
            _sessionFactory.EvictEntity(entityName, id);
        }

        public void EvictCollection(string roleName)
        {
            _sessionFactory.EvictCollection(roleName);
        }

        public void EvictCollection(string roleName, object id)
        {
            _sessionFactory.EvictCollection(roleName, id);
        }

        public void EvictQueries()
        {
            _sessionFactory.EvictQueries();
        }

        public void EvictQueries(string cacheRegion)
        {
            _sessionFactory.EvictQueries(cacheRegion);
        }

        public IStatelessSession OpenStatelessSession()
        {
            return _sessionFactory.OpenStatelessSession();
        }

        public IStatelessSession OpenStatelessSession(IDbConnection connection)
        {
            return _sessionFactory.OpenStatelessSession(connection);
        }

        public FilterDefinition GetFilterDefinition(string filterName)
        {
            return _sessionFactory.GetFilterDefinition(filterName);
        }

        public ISession GetCurrentSession()
        {
            return _sessionFactory.GetCurrentSession();
        }

        public IStatistics Statistics { get { return _sessionFactory.Statistics; } }
        public bool IsClosed { get { return _sessionFactory.IsClosed; } }
        public ICollection<string> DefinedFilterNames { get { return _sessionFactory.DefinedFilterNames; } }
    }
}
