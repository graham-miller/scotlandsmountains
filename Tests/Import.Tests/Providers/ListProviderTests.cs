using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.Providers;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.Import.Tests.Providers
{
    [TestFixture]
    public class ListProviderTests
    {
        [Test]
        public void GivenMockInputsThenConstructsListAsExpected()
        {
            const string id = "Id";
            const string listCode = "List code";
            const string name = "Name";
            const int order = 1;
            const string description = "Description";
            const bool enabled = true;

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate()).Returns(id);

            var mockDobihRecord = new Mock<IDobihRecord>();
            mockDobihRecord.Setup(x => x.Lists).Returns(new List<string> { listCode });

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> { mockDobihRecord.Object });

            var mockListInfoProvider = new Mock<IListInfoProvider>();
            mockListInfoProvider
                .Setup(x => x.GetListInfoFor(listCode))
                .Returns(new ListInfo
                {
                    Code = listCode,
                    Name = name,
                    Order = order,
                    Description = description,
                    Enabled = enabled
                });

            var sut = new ListProvider(mockIdGenerator.Object, mockDobihFile.Object, mockListInfoProvider.Object);

            var actual = sut.GetByDobihId(listCode);

            Assert.That(actual.Id, Is.EqualTo(id));
            Assert.That(actual.Name, Is.EqualTo(name));
            Assert.That(actual.Order, Is.EqualTo(order));
            Assert.That(actual.Description, Is.EqualTo(description));
        }
    }
}
