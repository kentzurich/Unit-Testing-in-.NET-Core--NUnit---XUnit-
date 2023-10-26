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
            //integration test
            //bankAccount = new(new LogBook());

            //unit test
            bankAccount = new(new LogFaker());
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var result = bankAccount.Deposit(100);
            var getBalance = bankAccount.GetBalance();

            Assert.That(result, Is.True);
            Assert.That(getBalance, Is.EqualTo(100));
        }
    }
}
