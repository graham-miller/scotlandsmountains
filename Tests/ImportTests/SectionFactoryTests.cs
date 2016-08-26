using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class SectionFactoryTests
    {
        [Test]
        public void WhenBuildingThenSectionConstructedCorrectly()
        {
            const string id = "ID";
            const string code = "Code";
            const string name = "Name";

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(id);

            var mockDobihRecord = new Mock<IDobihRecord>();
            mockDobihRecord.Setup(x => x.SectionCode).Returns(code);
            mockDobihRecord.Setup(x => x.SectionName).Returns(name);

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> {mockDobihRecord.Object});

            var sut = new SectionFactory(mockIdGenerator.Object);

            var actual = sut.BuildFrom(mockDobihFile.Object);

            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.Single().Id, Is.EqualTo(id));
            Assert.That(actual.Single().Name, Is.EqualTo(name));
        }
    }
}
