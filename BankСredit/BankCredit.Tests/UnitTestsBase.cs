using System;
using Moq;

namespace BankCredit.Tests
{
    public abstract class UnitTestsBase : IDisposable
    {
        protected MockRepository mockRepository;

        public UnitTestsBase()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

        }

        public void Dispose()
        {
            mockRepository.VerifyAll();
        }
    }
}