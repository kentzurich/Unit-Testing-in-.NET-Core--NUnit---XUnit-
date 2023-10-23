using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class Calculator_NUnitTests
    {
        [Test]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange - Initialization
            Calculator calc = new();

            //Act - Invoke method to test
            int result = calc.AddNumber(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(2);

            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }

        [Test]
        public void IsOddChecker_InputOddNumber_ReturnTrue()
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(1);

            //constraint model
            Assert.That(isOdd, Is.EqualTo(true));
            //classic model
            Assert.IsTrue(isOdd);
        }
    }
}
