using Xunit;

namespace Sparky
{
    public class Fibo_XUnitTests
    {
        private Fibo _fibo;
        public Fibo_XUnitTests()
        {
            _fibo = new Fibo();
        }

        [Fact]
        public void FiboListChecker_InputNumberOne_ReturnsValidFiboListRange()
        {
            List<int> expectedRange = new() { 0 };
            _fibo.Range = 1;

            var result = _fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            Assert.Equal(expectedRange.OrderBy(x => x), result);
            Assert.True(result.SequenceEqual(expectedRange));
        }

        [Fact]
        public void FiboListChecker_InputNumber6_ReturnsValidFiboListRange()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            _fibo.Range = 6;

            var result = _fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expectedRange, result);
        }
    }
}
