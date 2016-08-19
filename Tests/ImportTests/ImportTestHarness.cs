using System.Linq;
using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class ImportTestHarness
    {
        [Test]
        //[Ignore("Slow manual test harness")]
        public void ImportFromRawFiles()
        {
            var sut = new DomainRootFactory().Build();
            AssertDomain(sut);
            sut.Save();
        }

        [Test]
        //[Ignore("Slow manual test harness")]
        public void ImportFromDomainJson()
        {
            var sut = DomainRoot.Load();
            AssertDomain(sut);
        }

        private static void AssertDomain(DomainRoot domainRoot)
        {
            Assert.That(domainRoot.Maps.Landranger.Count(), Is.EqualTo(204));
            Assert.That(domainRoot.Maps.LandrangerActive.Count(), Is.EqualTo(204));
            Assert.That(domainRoot.Maps.Explorer.Count(), Is.EqualTo(403));
            Assert.That(domainRoot.Maps.ExplorerActive.Count(), Is.EqualTo(403));
            Assert.That(domainRoot.Maps.Discoverer.Count(), Is.EqualTo(18));
            Assert.That(domainRoot.Maps.Discovery.Count(), Is.EqualTo(73));

            Assert.That(domainRoot.Mountains.Count(), Is.EqualTo(20647));
        }
    }
}
