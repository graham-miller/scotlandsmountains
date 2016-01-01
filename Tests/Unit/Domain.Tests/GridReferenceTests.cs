using System;
using NUnit.Framework;
using ScotlandsMountains.Domain.ValueTypes;

namespace ScotlandsMountains.Domain.Tests
{
    [TestFixture]
    public class GridReferenceTests
    {
        [Test]
        public void ConstructorArgumentCannotBeNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new GridReference(null));
            Assert.That(exception.Message, Is.EqualTo("GridReference construction argument cannot be null.\r\nParameter name: gridReference"));
        }

        [Test]
        public void ThrowsExceptionIfGridReferenceIsNotValid()
        {
            var exception = Assert.Throws<ArgumentException>(() => new GridReference("AA1234567890"));
            Assert.That(exception.Message, Is.EqualTo("GridReference construction argument must be in the format \"[S|T|N|H|O][A-Z, not I]9999999999\"."));
        }

        [Test]
        public void AValidGridReferenceDoesNotThrow()
        {
            Assert.DoesNotThrow(() => new GridReference("NN1660071200"));
        }

        [Test]
        public void LettersAreCorrectlyMapped()
        {
            var sut = new GridReference("NN1660071200");
            Assert.That(sut.Letters, Is.EqualTo("NN"));
        }

        [Test]
        public void EastingsAreCorrectlyMapped()
        {
            var sut = new GridReference("NN1660071200");
            Assert.That(sut.Eastings, Is.EqualTo("16600"));
        }

        [Test]
        public void NorthingsAreCorrectlyMapped()
        {
            var sut = new GridReference("NN1660071200");
            Assert.That(sut.Northings, Is.EqualTo("71200"));
        }
    }
}
