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
    public class ClassificationFactoryTests
    {
        [Test]
        public void Test()
        {
            const string id = "ID";
            const string classificationCode = "Classification code";
            const string name = "Name";
            const int order = 1;
            const string description = "Description";

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(id);

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

            var mockDobihRecord = new Mock<IDobihRecord>();
            mockDobihRecord.Setup(x => x.Classifications).Returns(new List<string> {classificationCode});

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> {mockDobihRecord.Object});

            var sut = new ClassificationFactory(mockIdGenerator.Object, mockClassificationInfoProvider.Object);

            var actual = sut.BuildFrom(mockDobihFile.Object);

            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.Single().Id, Is.EqualTo(id));
            Assert.That(actual.Single().Name, Is.EqualTo(name));
            Assert.That(actual.Single().Order, Is.EqualTo(order));
            Assert.That(actual.Single().Description, Is.EqualTo(description));
        }
    }
}
