using System.Collections.Generic;

namespace HW_1_Classes_And_Git
{
    internal class Calculator
    {

        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("-----------------------------------------------");
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }

        public static double Modulus(double a, double b) => a % b;
        public static double Power(double a, double b) => Math.Pow(a, b);
    }
}
