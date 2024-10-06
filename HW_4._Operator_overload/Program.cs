using HW_4._Operator_overload;

// Testing Employee class:

Console.WriteLine("Testing Employee class:");

Employee emp1 = new("John Doe", 999);
Employee emp2 = new("Jane Smith", 888);
Employee emp3 = new("Vasya Ivanov", 777);
Employee emp4 = new("Den Carter", 1010);

emp1.PrintEmployeeInfo();
emp2.PrintEmployeeInfo();
emp3.PrintEmployeeInfo();
emp4.PrintEmployeeInfo();

int amount = 111;

emp1 = emp1 + amount;
emp2 = emp2 - amount;
bool isEqual = emp3 == emp4;
bool isGreater = emp1 > emp2;

Console.WriteLine($"Are salaries of {emp3.Name} and {emp4.Name} equal? {isEqual}");
Console.WriteLine($"Is {emp1.Name} salary greater than {emp2.Name}? {isGreater}");
Console.WriteLine($"Is {emp1.Name} salary Equals to {emp2.Name}? {emp1.Equals(emp2)}");
Console.WriteLine($"{emp1.Name} HashCode: {emp1.GetHashCode()}");
Console.WriteLine($"{emp2.Name} HashCode: {emp2.GetHashCode()}");
Console.WriteLine($"{emp3.Name} HashCode: {emp3.GetHashCode()}");
Console.WriteLine();

// Testing City class:

Console.WriteLine("Testing City class:");

City city1 = new City("Odessa", 1200000);
City city2 = new City("Kiyv", 2000000);

city1.PrintCityInfo();
city2.PrintCityInfo();

int population = 200000;
city1 = city1 + population;
city2 = city2 - population;

Console.WriteLine($"{city1.Name} New Population: {city1.Population}");
Console.WriteLine($"{city2.Name} New Population: {city2.Population}");

Console.WriteLine($"Are populations equal? {city1 == city2}");
Console.WriteLine($"Is {city2.Name} population greater than {city1.Name}? {city2 > city1}");
Console.WriteLine();

// Testing CreditCard class

Console.WriteLine("Testing CreditCard class:");
CreditCard card1 = new CreditCard("1234567890123456", 1000, "123");
CreditCard card2 = new CreditCard("9876543210987654", 999, "456");

card1.PrintCardInfo();
card2.PrintCardInfo();

int difference = 200;
card1 -= difference;
card2 += difference;

Console.WriteLine($"{card1.CardNumber} New Balance: {card1.Balance}");
Console.WriteLine($"{card2.CardNumber} New Balance: {card2.Balance}");

Console.WriteLine($"Are CVCs equal? {card1.CvcCode == card2.CvcCode}");
Console.WriteLine($"Are CardNunmers equal? {card1.CardNumber.Equals(card2.CardNumber)}");
Console.WriteLine($"Is {card1.CardNumber} balance greater than {card2.CardNumber}? {card1 > card2}");
Console.WriteLine($"{card1.CardNumber} HashCode: {card1.GetHashCode()}");
Console.WriteLine($"{card2.CardNumber} HashCode: {card2.GetHashCode()}");
Console.WriteLine();

// Testing Matrix class

Console.WriteLine("Testing Matrix class:");
Matrix matrix1 = new Matrix(2, 2);
Matrix matrix2 = new Matrix(2, 2);

matrix1[0, 0] = 1; matrix1[0, 1] = 2;
matrix1[1, 0] = 3; matrix1[1, 1] = 4;

matrix2[0, 0] = 5; matrix2[0, 1] = 6;
matrix2[1, 0] = 7; matrix2[1, 1] = 8;


Matrix sum = matrix1 + matrix2;
Console.WriteLine("Sum of Matrices:");
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.Write(sum[i, j] + " ");
    }
    Console.WriteLine();
}

Matrix diff = matrix1 - matrix2; 
Console.WriteLine("Difference of Matrices:");
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.Write(diff[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine($"Are matrices equal? {matrix1 == matrix2}");
