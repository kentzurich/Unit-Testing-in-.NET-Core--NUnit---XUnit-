using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class BankAccount_NUnitTests
    {
        private BankAccount bankAccount;
        [SetUp] 
        public void SetUp() 
        {
           
        }

        [Test]
        public void BankDepositLogFaker_Add100_ReturnTrue()
        {
            //integration test
            //bankAccount = new(new LogBook());

            //unit test
            BankAccount bankAccount1 = new(new LogFaker());

            var result = bankAccount1.Deposit(100);
            var getBalance = bankAccount1.GetBalance();

            Assert.That(result, Is.True);
            Assert.That(getBalance, Is.EqualTo(100));
        }

        [Test]
        public void BankDepositMoq_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);
            var getBalance = bankAccount.GetBalance();

            Assert.That(result, Is.True);
            Assert.That(getBalance, Is.EqualTo(100));
        }
    }
}
