using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class Customer_NUnitTests
    {
        private Customer _customer;
        [SetUp] 
        public void SetUp() 
        { 
            _customer = new Customer();
        }

        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
           // var customer = new Customer();

            //Act
            _customer.GreetAndCombineNames("Kent", "Zurich");

            Assert.Multiple(() =>
            {
                //Assert
                Assert.AreEqual(_customer.GreetMessage, "Hello, Kent Zurich");

                Assert.That(_customer.GreetMessage, Is.EqualTo("Hello, Kent Zurich"));
                Assert.That(_customer.GreetMessage, Does.Contain("Kent Zurich"));
                Assert.That(_customer.GreetMessage, Does.Contain("kent zurich").IgnoreCase);
                Assert.That(_customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(_customer.GreetMessage, Does.EndWith("Zurich"));
                Assert.That(_customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //Arrange
            //var customer = new Customer();

            //Act


            //Assert
            Assert.IsNull(_customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountRange()
        {
            int result = _customer.Discount;

            Assert.That(result, Is.InRange(10, 25));
        }
    }
}
