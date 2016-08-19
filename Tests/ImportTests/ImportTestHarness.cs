using System.Linq;
using NUnit.Framework;
using ScotlandsMountains.Import;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class ImportTestHarness
    {
        [Test]
        [Ignore("Slow manual test harness")]
        public void ExecuteImportTestHarness()
        {
            var sut = new DomainRootFactory().Build();

            Assert.That(sut.Maps.Landranger.Count(), Is.EqualTo(204));
            Assert.That(sut.Maps.LandrangerActive.Count(), Is.EqualTo(204));
            Assert.That(sut.Maps.Explorer.Count(), Is.EqualTo(403));
            Assert.That(sut.Maps.ExplorerActive.Count(), Is.EqualTo(403));
            Assert.That(sut.Maps.Discoverer.Count(), Is.EqualTo(18));
            Assert.That(sut.Maps.Discovery.Count(), Is.EqualTo(73));

            Assert.That(sut.Mountains.Count(), Is.EqualTo(20647));
        }
    }
}
