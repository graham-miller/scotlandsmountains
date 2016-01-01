using NUnit.Framework;

namespace ScotlandsMountains.Data.Tests
{
    [TestFixture]
    public class Data
    {
        [Test]
        public void DataFiddle()
        {
            var session = SessionFactory.Instance.OpenSession();
        }
    }
}
