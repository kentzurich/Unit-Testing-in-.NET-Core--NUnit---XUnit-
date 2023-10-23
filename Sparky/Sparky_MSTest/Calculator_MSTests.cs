using Sparky;

namespace Sparky_MSTest
{
    [TestClass]
    public class Calculator_MSTests
    {
        [TestMethod]
        public void AddNumber_InputTwoInt_GetCorrectAddition()
        {
            //Arrange - Initialization
            Calculator calc = new();

            //Act - Invoke method to test
            int result = calc.AddNumber(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
