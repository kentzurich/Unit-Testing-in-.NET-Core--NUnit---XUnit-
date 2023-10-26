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

        [Test]
        [TestCase(200, 100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(x => x
            .LogBalanceAfterWithdrawal(It.IsInRange<int>(
                int.MinValue, 
                -1, 
                Moq.Range.Inclusive)))
            .Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.IsFalse(result);
        }
    }
}
