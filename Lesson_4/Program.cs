using SecondLesson.oop;
using System.Text;
using ThirdLesson.abstractClasses;
using ThirdLesson.objAndMethods;
using ThirdLesson.someStandardInterfaces;
using ThirdLesson.someStandardInterfacesV2;

// Запрограмуйте клас Money(об'єкт класу оперує однією валютою) для роботи з грошима. 

//У класі мають бути передбачені: поле для зберігання цілої частини грошей (долари, євро, гривні тощо) і поле для зберігання копійок (центи, євроценти, копійки тощо)

//Реалізувати методи виведення суми на екран, задання значень частин

//(цілої частини грошей та копійок). 

//На базі класу Money створити клас Product для роботи з продуктом або товаром.

//Реалізувати метод, який дозволяє зменшити ціну на задане число.

//Для кожного з класів реалізувати необхідні методи і поля. 

// Додати iнкапсуляцiю до полiв та методiв якщо треба.

//
//Створити клас калькулятор.

//Реалізувати основні методи: додавання, віднімання, множення, розподіл, тощо.

namespace Lesson
{
    public class Money
    {
        private int _integerPart;
        private int _coinPart;

        public int IntegerPart
        {
            get
            {
                return _integerPart;
            }
            set
            {
                if(value > 0)
                {
                    _integerPart = value;
                }
            }
        }

        public int CoinPart
        {
            get
            {
                return _coinPart;
            }
            set
            {
                if (value > 0 && value < 100)
                {
                    _coinPart = value;
                }
            }
        }

        public void ShowSum()
        {
            Console.WriteLine($"{_integerPart} grn {_coinPart} coins");
        }

        public void SetSum(int integerPart, int coinPart)
        {
            IntegerPart = integerPart;
            CoinPart = coinPart;
        }
    }

    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public Money? MoneySum { get; set; }

        public void ShowProduct()
        {
            Console.WriteLine($"Product: {Name} and Price: {MoneySum?.IntegerPart} grn {MoneySum?.CoinPart} coins");
        }
    }

    //
    public class Calculator
    {
        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public Calculator(int num1, int num2)
        {
            Number1 = num1;
            Number2 = num2;
        }

        public int Add() => Number1 + Number2;

        public static int Sub(int num1, int num2) => num1 - num2;

        public static int Mult(int num1, int num2)
        {
            return num1 * num2;
        }

        public static int Division(int num1, int num2) => num1 / num2;
    }

    public interface IPerson
    {
        public void ShowInfo();
    }

    public abstract class Person : IPerson
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string? Name { get; set; }
        public int Age { get; set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, age: {Age}");
        }
    }

    public class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, int age, string company) : base(name, age)
        {
            Company = company;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Company: {Company}");
        }

        public void GetCompanyName()
        {
            Console.WriteLine(Company);
        }
    }

    public class Program
    {
        public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Lesson4.Example1.StartTest();
            Lesson4.Example2.StartTest();

            // Example5.StartTest();

            // Example6.StartTest();

            // Example7.StartTest();

            // Example4.StartTest();

            //var vasya = new Employee("Vasya", 33, "Google");
            //vasya.ShowInfo();
            //((IPerson)vasya).ShowInfo();

            //IPerson pers = vasya;
            //pers.ShowInfo();

            //var car = new Car("BMW");
            //car.Info();
            //Transport tran = new Aircraft("BMW");
            //tran.Info();
            //tran = car;
            //tran.Info();

            //var money1 = new Money
            //{
            //    IntegerPart = 12,
            //    CoinPart = 20
            //};

            //Console.WriteLine(money1.IntegerPart); // get
            //money1.IntegerPart = 15; // set
            //Console.WriteLine(money1.IntegerPart); // get

            //money1.ShowSum();
            //money1.SetSum(100, 35);
            //money1.ShowSum();

            //var myProd = new Product
            //{
            //    MoneySum = new Money
            //    {
            //        IntegerPart = 123,
            //        CoinPart = 50
            //    },
            //    Name = "Chips"
            //};

            //Console.WriteLine(myProd.MoneySum.IntegerPart);
            //myProd.ShowProduct();

            // string name = Console.ReadLine() ?? string.Empty;

            //var myPhone = new SmartPhone("Iphone", 123.44m, 333);
            //myPhone.Print();
            //Console.WriteLine("------------");
            //PhoneBase tempPhone = myPhone;
            //tempPhone.Print();

            //IGraphic graphic = new ConsoleApp();
            //graphic.ShowText("Hello");
            //graphic = new Phone();
            //graphic.ShowText("Hello");


            // Example1.StartTest();
            // Example2.StartTest();
            // xample3.StartTest();
            // Example4.StartTest();
            // Example5.StartTest();
        }
    }
}

