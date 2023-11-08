using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class Fibo_XUnitTests
    {
        private Fibo _fibo;
        [SetUp]
        public void SetUp()
        {
            _fibo = new Fibo();
        }

        [Test]
        public void FiboListChecker_InputNumberOne_ReturnsValidFiboListRange()
        {
            List<int> expectedRange = new() { 0 };
            _fibo.Range = 1;

            var result = _fibo.GetFiboSeries();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

        [Test]
        public void FiboListChecker_InputNumber6_ReturnsValidFiboListRange()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            _fibo.Range = 6;

            var result = _fibo.GetFiboSeries();

            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }
    }
}
