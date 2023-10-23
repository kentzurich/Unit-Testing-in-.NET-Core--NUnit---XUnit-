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
            string fullName = customer.GreetAndCombineNames("Kent", "Zurich");

            //Assert
            Assert.AreEqual(fullName, "Hello, Kent Zurich");

            Assert.That(fullName, Is.EqualTo("Hello, Kent Zurich"));
            Assert.That(fullName, Does.Contain("Kent Zurich"));
            Assert.That(fullName, Does.Contain("kent zurich").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello"));
            Assert.That(fullName, Does.EndWith("Zurich"));
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
    }
}
