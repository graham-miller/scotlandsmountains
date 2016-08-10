using NUnit.Framework;
using ScotlandsMountains.Import;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class ImporterTests
    {
        [Test]
        public void ImportTestHarness()
        {
            var sut = Importer.Import();
            Assert.Pass();
        }
    }
}
