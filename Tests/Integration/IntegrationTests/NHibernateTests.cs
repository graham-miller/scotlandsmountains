using System;
using System.IO;
using System.Reflection;
using DataAccess;
using NUnit.Framework;
using ScotlandsMountains.Domain.Dobih.Csv;

namespace ScotlandsMountains.IntegrationTests
{
    [TestFixture]
    public class NHibernateTests
    {
        [Test]
        public void CreateDatabase()
        {
            NHibernateBootstrapper.Bootstrap(GetConnectionString());
            NHibernateBootstrapper.CreateSchema();
        }

        [Test]
        public void ImportMountainDataFromDobihToDatabase()
        {
            var sut = new Importer(GetPathToDobihCsv());

            NHibernateBootstrapper.Bootstrap(GetConnectionString());
            NHibernateBootstrapper.CreateSchema();

            using (var session = NHibernateBootstrapper.GetSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var mountain in sut.Mountains)
                    session.SaveOrUpdate(mountain);

                foreach (var map in sut.Maps)
                    session.SaveOrUpdate(map);

                foreach (var area in sut.Areas)
                    session.SaveOrUpdate(area);

                foreach (var table in sut.Tables)
                    session.SaveOrUpdate(table);

                transaction.Commit();
            }
        }

        private string GetConnectionString()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return "Data Source=" + Path.GetDirectoryName(path) + @"\ScotlandsMountains.sdf";
        }

        private string GetPathToDobihCsv()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path) + @"\DoBIH.csv";
        }
    }
}
