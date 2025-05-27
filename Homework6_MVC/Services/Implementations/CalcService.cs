namespace Homework6_MVC.Services.Implementations
{
    public class CalcService : ICalcService
    {
        public double Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return Sum(num1, num2);
                case "-":
                    return Sum(num1, -num2);
                case "*":
                    return Multiply(num1, num2);
                case "/":
                    return Divide(num1, num2);
                default:
                    throw new Exception("Unexpected operation");
            }
        }

        private double Divide(double num1, double num2)
        {
            if (num2 == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return num1 / num2;
        }

        private double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        private double Sum(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
