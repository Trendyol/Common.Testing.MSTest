using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace Common.Testing.MSTest
{
    [TestClass]
    public abstract class TestBase
    {
        protected IFixture FakeDataRepository { get; private set; }
        private MockRepository _mockRepository;

        protected bool VerifyAll { get; set; }

        [TestInitialize]
        public void BeforeInitialize()
        {
            FakeDataRepository = new Fixture();
            FakeDataRepository.EnableCustomization<SupportMutableValueTypesCustomization>();

            VerifyAll = true;
            _mockRepository = new MockRepository(MockBehavior.Strict);
            Initialize();
        }

        [TestCleanup]
        public void BeforeCleanUp()
        {
            if (VerifyAll)
                _mockRepository.VerifyAll();
            else
                _mockRepository.Verify();

            CleanUp();
        }

        protected T Create<T>()
        {
            return FakeDataRepository.Create<T>();
        }

        protected IEnumerable<T> CreateMany<T>()
        {
            return FakeDataRepository.CreateMany<T>();
        }

        protected IEnumerable<T> CreateMany<T>(int count)
        {
            return FakeDataRepository.CreateMany<T>(count);
        }

        protected Mock<T> MockFor<T>() where T : class
        {
            return _mockRepository.Create<T>();
        }

        protected Mock<T> MockFor<T>(object[] @params) where T : class
        {
            return _mockRepository.Create<T>(@params);
        }

        protected virtual void Initialize()
        {

        }

        protected virtual void CleanUp()
        {

        }
    }
}
