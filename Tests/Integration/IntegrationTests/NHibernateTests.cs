using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using ScotlandsMountains.DataAccess;
using ScotlandsMountains.Domain.Dobih.Csv;

namespace ScotlandsMountains.IntegrationTests
{
    [TestFixture]
    public class NHibernateTests
    {
        [Test]
        public void CreateDatabase()
        {
            NHibernateBootstrapper.Bootstrap();
            NHibernateBootstrapper.CreateSchema();
        }

        [Test]
        public void ImportMountainDataFromDobihToDatabase()
        {
            var sut = new Importer(GetPathToDobihCsv());

            NHibernateBootstrapper.Bootstrap();
            NHibernateBootstrapper.CreateSchema();

            using (var session = NHibernateBootstrapper.GetSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var map in sut.Maps)
                    session.SaveOrUpdate(map);

                foreach (var area in sut.Areas)
                    session.SaveOrUpdate(area);

                foreach (var table in sut.Tables)
                    session.SaveOrUpdate(table);

                foreach (var mountain in sut.Mountains)
                    session.SaveOrUpdate(mountain);

                transaction.Commit();
            }
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
