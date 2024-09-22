using HW_1_Classes_And_Git;

Console.Write("Enter the first number: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter 1-character action you want to perform: + , - , * , / , % , p");
char action = char.Parse(Console.ReadLine());

Console.Write("Enter the second number: ");
double num2 = Convert.ToDouble(Console.ReadLine());

double result = 0;
switch (action)
{
    case '+':
        result = Calculator.Add(num1, num2);
        break;
    case '-':
        result = Calculator.Subtract(num1, num2);
        break;
    case '*':
        result = Calculator.Multiply(num1, num2);
        break;
    case '/':
        result = Calculator.Divide(num1, num2);
        break;
    case '%':
        result = Calculator.Modulus(num1, num2);
        break;
    case 'p':
        result = Calculator.Power(num1, num2);
        break;
    default:
        Console.WriteLine("You entered incorrect action");
        break;
}

bool isActionCorrect = action == '+' || action == '-' || action == '*' || action == '/' || action == '%' || action == 'p';

if (result == double.PositiveInfinity && !isActionCorrect)
{
    Console.WriteLine("Something wrong!");
    Console.WriteLine($"Result = ({num1} {action} {num2}) = {result}");
}
Console.WriteLine("-----------------------------------------------");
Console.WriteLine($"Result = ({num1} {action} {num2}) = {result}");
Console.WriteLine("-----------------------------------------------");
Console.WriteLine("Addition (+): " + Calculator.Add(num1, num2));
Console.WriteLine("Subtraction (-): " + Calculator.Subtract(num1, num2));
Console.WriteLine("Multiplication (*): " + Calculator.Multiply(num1, num2));
Console.WriteLine("Division (/): " + Calculator.Divide(num1, num2));
Console.WriteLine("Modulus (%): " + Calculator.Modulus(num1, num2));
Console.WriteLine("Power (p): " + Calculator.Power(num1, num2));
