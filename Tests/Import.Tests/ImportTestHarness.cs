using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;
using ScotlandsMountains.Import.Providers;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.Import.Tests
{
    [TestFixture]
    public class ImportTestHarness
    {
        private const int IdGeneratorSequenceSeed = 30000; // IDs below 30,000 are reserved for mountains

        [Test, Order(1)]
        //[Ignore("Slow manual test harness")]
        public void ImportFromRawFiles()
        {
            var idGenerator = new IdGenerator(IdGeneratorSequenceSeed);
            var dobihFile = new DobihFile();

            var parameters = new ImportParameters
            {
                DobihFile = dobihFile,
                MapProvider = new MapProvider(idGenerator, new OsFile()),
                IdGenerator = idGenerator,
                CountryProvider = new CountryProvider(idGenerator),
                ListProvider = new ListProvider(idGenerator, dobihFile, new ListInfoProvider()),
                SectionProvider = new SectionProvider(idGenerator, dobihFile),
            };

            var sut = new DomainRootFactory(parameters).Build();

            AssertDomain(sut);
            sut.Save();
        }

        [Test, Order(2), MaxTime(1000)]
        //[Ignore("Slow manual test harness")]
        public void ImportFromDomainJson()
        {
            var sut = DomainRoot.Load();
            AssertDomain(sut);
        }

        private static void AssertDomain(IDomainRoot domainRoot)
        {
            Assert.That(domainRoot.Maps.Landranger.Count, Is.EqualTo(204));
            Assert.That(domainRoot.Maps.LandrangerActive.Count, Is.EqualTo(204));
            Assert.That(domainRoot.Maps.Explorer.Count, Is.EqualTo(403));
            Assert.That(domainRoot.Maps.ExplorerActive.Count, Is.EqualTo(403));
            Assert.That(domainRoot.Maps.Discoverer.Count, Is.EqualTo(18));
            Assert.That(domainRoot.Maps.Discovery.Count, Is.EqualTo(73));

            Assert.That(domainRoot.Lists.Count, Is.EqualTo(24));

            Assert.That(domainRoot.Sections.Count, Is.EqualTo(71));

            Assert.That(domainRoot.Mountains.Count, Is.EqualTo(12135));
        }
    }
}
