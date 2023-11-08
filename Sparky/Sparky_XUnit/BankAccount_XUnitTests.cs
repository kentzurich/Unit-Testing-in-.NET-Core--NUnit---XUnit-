using Moq;
using Xunit;

namespace Sparky
{
    public class BankAccount_XUnitTests
    {
        private BankAccount bankAccount;
        public BankAccount_XUnitTests()
        {

        }

        [Fact]
        public void BankDepositMoq_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);
            var getBalance = bankAccount.GetBalance();

            Assert.True(result);
            Assert.Equal(100, getBalance);
        }

        [Theory]
        [InlineData(200, 100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
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

            Assert.False(result);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x => x
                .MessageWithReturnString(It.IsAny<string>()))
                .Returns((string str) => str.ToLower());

            Assert.Equal(desiredOutput, logMock.Object.MessageWithReturnString("Hello"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x => x
                .LogWithOutputResult(It.IsAny<string>(), out desiredOutput))
                .Returns(true);

            string result = string.Empty;

            Assert.True(logMock.Object.LogWithOutputResult("Kent", out result));
            Assert.Equal(desiredOutput, result);
        }

        [Fact]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);

            Assert.True(logMock.Object.LogWithRefObj(ref customer));
            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Fact]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            //when assigning a value in mock. need to call SetupAllProperties
            logMock.SetupAllProperties();

            //logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("warning");

            logMock.Object.LogSeverity = 100;

            Assert.Equal(100, logMock.Object.LogSeverity);
            Assert.Equal("warning", logMock.Object.LogType);

            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Kent");

            Assert.Equal("Hello, Kent", logTemp);

            //callbacks
            int counter = 5;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => counter++);
            logMock.Object.LogToDb("Kent");
            logMock.Object.LogToDb("Kent");

            Assert.Equal(7, counter);
        }

        [Fact]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            //Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //verification
            logMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(x => x.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(x => x.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(x => x.LogSeverity, Times.Once);
        }
    }
}
