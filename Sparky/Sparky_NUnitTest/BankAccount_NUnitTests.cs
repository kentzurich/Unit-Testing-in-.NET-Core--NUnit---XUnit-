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

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x => x
                .MessageWithReturnString(It.IsAny<string>()))
                .Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnString("Hello"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x => x
                .LogWithOutputResult(It.IsAny<string>(), out desiredOutput))
                .Returns(true);

            string result = string.Empty;

            Assert.IsTrue(logMock.Object.LogWithOutputResult("Kent", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            //when assigning a value in mock. need to call SetupAllProperties
            logMock.SetupAllProperties();

            //logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("warning");

            logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Kent");

            Assert.That(logTemp, Is.EqualTo("Hello, Kent"));

            //callbacks
            int counter = 5;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => counter++);
            logMock.Object.LogToDb("Kent");
            logMock.Object.LogToDb("Kent");

            Assert.That(counter, Is.EqualTo(7));
        }
    }
}
