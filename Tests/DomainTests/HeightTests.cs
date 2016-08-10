using NUnit.Framework;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.DomainTests
{
    [TestFixture]
    public class HeightTests
    {
        [Test]
        public void WhenSettingMetresThenFeetConvertedCorrectly()
        {
            var sut = new Height { Metres = 1 };
            Assert.That(sut.Metres, Is.EqualTo(1));
            Assert.That(sut.Feet, Is.EqualTo(1 * Height.MetresToFeetConversionFactor).Within(0.5));

        }

        [Test]
        public void WhenSettingFeetThenMetresConvertedCorrectly()
        {
            var sut = new Height { Feet = 1 };
            Assert.That(sut.Feet, Is.EqualTo(1));
            Assert.That(sut.Metres, Is.EqualTo(1 / Height.MetresToFeetConversionFactor).Within(0.5));
        }
    }
}
