using NUnit.Framework;

namespace ScotlandsMountains.Tests.Common
{
    public class ArrangeActAssert<T>
    {
        protected T SubjectUnderTest;

        [TestFixtureSetUp]
        public void MainSetup()
        {
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        protected void MainTeardown()
        {
            CleanUp();
        }

        protected virtual void Act() { }
        protected virtual void Arrange() { }
        protected virtual void CleanUp() { }
    }
}
