namespace Sparky
{
    public class Calculator
    {
        public int AddNumber(int a, int b)
        {
            return a + b;
        }

        public double AddNumbersDouble(double a, double b)
        {
            return a + b;
        }

        public bool IsOddNumber(int a)
        {
            return (a % 2 != 0);
        }
    }
}