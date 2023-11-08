using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Sparky
{
    [TestFixture]
    public class Calculator_XUnitTests
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
        [TestCase(11)]
        [TestCase(13)]
        //[TestCase(13, 12)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(a);

            //constraint model
            Assert.That(isOdd, Is.EqualTo(true));
            //classic model
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new();

            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.96
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange - Initialization
            Calculator calc = new();

            //Act - Invoke method to test
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, .2);
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

            //Act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            //Assert.AreEqual(expectedOddRange, result);
            //Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered.Ascending);
            Assert.That(result, Is.Unique);
        }
    }
}
