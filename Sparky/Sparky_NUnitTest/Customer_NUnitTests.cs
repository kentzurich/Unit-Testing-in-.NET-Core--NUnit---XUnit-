using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class Customer_NUnitTests
    {
        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            var customer = new Customer();

            //Act
            customer.GreetAndCombineNames("Kent", "Zurich");

            //Assert
            Assert.AreEqual(customer.GreetMessage, "Hello, Kent Zurich");

            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Kent Zurich"));
            Assert.That(customer.GreetMessage, Does.Contain("Kent Zurich"));
            Assert.That(customer.GreetMessage, Does.Contain("kent zurich").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
            Assert.That(customer.GreetMessage, Does.EndWith("Zurich"));
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //Arrange
            var customer = new Customer();

            //Act


            //Assert
            Assert.IsNull(customer.GreetMessage);
        }
    }
}
