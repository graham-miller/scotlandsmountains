using NUnit.Framework;
using ScotlandsMountains.Domain.ValueTypes;

namespace ScotlandsMountains.Domain.Tests
{
    [TestFixture]
    public class MapDescriptionTests
    {
        [Test,Ignore]
        public void TestGet()
        {
            Assert.That(MapDescription.Get("Landranger 63"), Is.EqualTo("Firth of Clyde"));
        }
    }
}
