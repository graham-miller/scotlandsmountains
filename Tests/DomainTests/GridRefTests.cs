using NUnit.Framework;
using System;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.DomainTests
{
    [TestFixture]
    public class GridRefTests
    {
        [Test]
        public void GivenSixFigureOsGridReferenceThenCorrectlyConstructed()
        {
            var sut = new GridRef("NM123456");
            Assert.That(sut.SixFigure, Is.EqualTo("NM123456"));
            Assert.That(sut.TenFigure, Is.EqualTo("NM1230045600"));
        }

        [Test]
        public void GivenTenFigureOsGridReferenceThenCorrectlyConstructed()
        {
            var sut = new GridRef("NM1234567890");
            Assert.That(sut.SixFigure, Is.EqualTo("NM123678"));
            Assert.That(sut.TenFigure, Is.EqualTo("NM1234567890"));
        }

        [Test]
        public void GivenSixFigureIrishGridReferenceThenCorrectlyConstructed()
        {
            var sut = new GridRef("B123456");
            Assert.That(sut.SixFigure, Is.EqualTo("B123456"));
            Assert.That(sut.TenFigure, Is.EqualTo("B1230045600"));
        }

        [Test]
        public void GivenTenFigureIrishGridReferenceThenCorrectlyConstructed()
        {
            var sut = new GridRef("B1234567890");
            Assert.That(sut.SixFigure, Is.EqualTo("B123678"));
            Assert.That(sut.TenFigure, Is.EqualTo("B1234567890"));
        }

        [Test]
        public void GivenInvalidThenThrows()
        {
            Assert.Throws<ArgumentException>(() => new GridRef(string.Empty));
        }
    }
}
