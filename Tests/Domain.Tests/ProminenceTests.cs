using NUnit.Framework;

namespace ScotlandsMountains.Domain.Tests
{
    [TestFixture]
    public class ProminenceTests
    {
        [Test]
        public void GivenProminenceAboveGridRefThenToStringIsFormattedCorrectly()
        {
            var sut = new Prominence
            {
                Metres = 500,
                KeyCol = "NM1234567890",
                KeyColHeight = new Height
                {
                    Metres = 1000
                }
            };
            Assert.That(sut.ToString(), Is.EqualTo("500m (1,640ft) above col (1,000m (3,281ft))"));
        }

        [Test]
        public void GivenProminenceAboveFeatureThenToStringIsFormattedCorrectly()
        {
            var sut = new Prominence
            {
                Metres = 500,
                KeyCol = "Sea",
                KeyColHeight = new Height
                {
                    Metres = 1000
                }
            };
            Assert.That(sut.ToString(), Is.EqualTo("500m (1,640ft) above Sea (1,000m (3,281ft))"));
        }
    }
}
