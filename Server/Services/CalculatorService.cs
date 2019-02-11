namespace Server.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double Add(double x, double y) => x + y;

        public double Divide(double x, double y) => x / y;

        public double Multiply(double x, double y) => x * y;

        public double Subtract(double x, double y) => x - y;
    }
}
