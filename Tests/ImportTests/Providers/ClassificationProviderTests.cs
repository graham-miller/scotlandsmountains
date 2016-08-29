using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Providers;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.ImportTests.Providers
{
    [TestFixture]
    public class ClassificationProviderTests
    {
        [Test]
        public void GivenMockInputsThenConstructsClassificationAsExpected()
        {
            const string id = "Id";
            const string classificationCode = "Classification code";
            const string name = "Name";
            const int order = 1;
            const string description = "Description";

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(id);

            var mockDobihRecord = new Mock<IDobihRecord>();
            mockDobihRecord.Setup(x => x.Classifications).Returns(new List<string> { classificationCode });

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> { mockDobihRecord.Object });

            var mockClassificationInfoProvider = new Mock<IClassificationInfoProvider>();
            mockClassificationInfoProvider
                .Setup(x => x.GetClassificationInfoFor(classificationCode))
                .Returns(new ClassificationInfo
                {
                    Code = classificationCode,
                    Name = name,
                    Order = order,
                    Description = description
                });

            var sut = new ClassificationProvider(mockIdGenerator.Object, mockDobihFile.Object, mockClassificationInfoProvider.Object);

            var actual = sut.GetByDobihId(classificationCode);

            Assert.That(actual.Id, Is.EqualTo(id));
            Assert.That(actual.Name, Is.EqualTo(name));
            Assert.That(actual.Order, Is.EqualTo(order));
            Assert.That(actual.Description, Is.EqualTo(description));
        }
    }
}
