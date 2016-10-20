using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Providers;

namespace ScotlandsMountains.Import.Tests.Providers
{
    [TestFixture]
    public class SectionProviderTests
    {
        [Test]
        public void GivenMockInputsThenConstructsSectionAsExpected()
        {
            const string id = "Id";
            const string sectionCode = "Section code";
            const string sectionName = "Section name";

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(id);

            var mockDobihRecord = new Mock<IDobihRecord>();
            mockDobihRecord.Setup(x => x.SectionCode).Returns(sectionCode);
            mockDobihRecord.Setup(x => x.SectionName).Returns(sectionName);

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> { mockDobihRecord.Object });

            var sut = new SectionProvider(mockIdGenerator.Object, mockDobihFile.Object);

            var actual = sut.GetByDobihId(sectionName);

            Assert.That(actual.Id, Is.EqualTo(id));
            Assert.That(actual.Name, Is.EqualTo(sectionName));
        }
    }
}
