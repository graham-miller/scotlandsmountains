﻿using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Os;
using ScotlandsMountains.Import.Providers;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.ImportTests
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
                ClassificationProvider = new ClassificationProvider(idGenerator, dobihFile, new ClassificationInfoProvider()),
                SectionProvider = new SectionProvider(idGenerator, dobihFile),
            };

            var sut = new DomainRootFactory(parameters).Build();

            AssertDomain(sut);
            sut.Save();
        }

        [Test, Order(2)]
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

            Assert.That(domainRoot.Classifications.Count, Is.EqualTo(57));

            Assert.That(domainRoot.Sections.Count, Is.EqualTo(135));

            Assert.That(domainRoot.Mountains.Count, Is.EqualTo(20647));
        }
    }
}
