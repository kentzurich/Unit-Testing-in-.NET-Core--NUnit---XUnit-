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
            Assert.That(fullName, Is.EqualTo("Hello, Kent Zurich"));
        }
    }
}
