using NUnit.Framework;
using ScotlandsMountains.Import;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class ImportTestHarness
    {
        [Test,Ignore("Slow manual test harness")]
        public void ExecuteImportTestHarness()
        {
            Assert.DoesNotThrow(() => new DomainRootFactory().Build());
        }
    }
}
