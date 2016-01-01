using System;
using NUnit.Framework;
using ScotlandsMountains.Import.OrdnanceSurvey;

namespace ScotlandsMountains.Import.Tests.OrdnanceSurveyTests
{
    [TestFixture]
    public class RawRecordTests
    {
        private const string Example1 = @"OL45 The Cotswolds, Burford, Chipping Camden, Cirencester & Stow-on-the-Wold 9780319467930 10/10/14 A2";
        private const string Example2 = @"101 Isles of Scilly 9780319463437 13/01/14 B1";

        [Test]
        public void TestWithExample1()
        {
            var sut = new Record(Example1);

            Assert.That(sut.Sheet, Is.EqualTo("OL45"));
            Assert.That(sut.Name, Is.EqualTo("The Cotswolds, Burford, Chipping Camden, Cirencester & Stow-on-the-Wold"));
            Assert.That(sut.Isbn, Is.EqualTo("9780319467930"));
            Assert.That(sut.PublicationDate, Is.EqualTo(new DateTime(2014, 10, 10)));
            Assert.That(sut.Edition, Is.EqualTo("A2"));
        }

        [Test]
        public void TestWithExample2()
        {
            var sut = new Record(Example2);

            Assert.That(sut.Sheet, Is.EqualTo("101"));
            Assert.That(sut.Name, Is.EqualTo("Isles of Scilly"));
            Assert.That(sut.Isbn, Is.EqualTo("9780319463437"));
            Assert.That(sut.PublicationDate, Is.EqualTo(new DateTime(2014, 01, 13)));
            Assert.That(sut.Edition, Is.EqualTo("B1"));
        }
    }
}
