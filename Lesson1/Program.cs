// using SecondLesson.static_examples;
using System.Text;
using SecondLesson.oop;

namespace Lesson1
{
	// v1
	//class Person
	//{
	//	public string name;   // ім'я
	//	public int age;                     // вік
	//	public Company company;

	//	public Person()
	//	{
	//		name = "Undefined";
	//		age = 18;
	//		company = new Company();
	//	}

	//	public void Print()
	//	{
	//		Console.WriteLine($"Name: {name}  Age: {age} Company: {company.title}");
	//	}
	//}

	class Company
	{
		public string title = "Unknown";
	}

	// Ланцюжок виклику конструкторів
	public class PersonV4
	{
		public string name;
		public int age;
		public PersonV4() : this("Неизвестно")    // 1 конструктор
		{
			Console.WriteLine("1 конструктор");
		}
		public PersonV4(string name) : this(name, 18) // 2 конструктор
		{
			Console.WriteLine("2 конструктор");
		}
		public PersonV4(string name, int age)     // 3 конструктор
		{
			this.name = name;
			this.age = age;
			Console.WriteLine("3 конструктор");
		}
		public void Print() => Console.WriteLine($"Name: {name}  Age: {age}");

		// Деконструктори

		/*
        Деконструктори (не плутати з деструкторами) дозволяють виконати декомпозицію об'єкта окремі частини.
        */

		public void Deconstruct(out string personName, out int personAge, ref int number, in int num)
		{
			Console.WriteLine(number);
			personName = name;
			personAge = age;

			Console.WriteLine(personName);
			//number = 1111;
			Console.WriteLine(num);
			// num = 11;
		}

		public void SwapNumber(ref int number1, ref int number2)
		{
			var temp = number1;
			number1 = number2;
			number2 = temp;
		}
	}

	public class Demo
	{
		public const int number1 = 10;
		public readonly int number2 = 20;

		public Demo()
		{
			// number1 = 10;
			number2 = 20;
		}

		public void Print()
		{
		}
	}

	public class Program
	{
		public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
		{
			Console.OutputEncoding = Encoding.UTF8;

			var person = new Person("firstName")
			{
				TestInfo = "demo"
			};
			Console.WriteLine(person.TestInfo);
			// person.TestInfo = "qqqq";

			//Console.WriteLine(InvoiceTypes.Urgent);
			//var result = MathOperations.Add(1, 4);
			//Console.WriteLine(result);

			//var pers = new PersonV3(30);
			//pers.CheckRetirementStatus(new PersonV3(44));

			//var user = new PersonV4();
			//string name = "Vasya";
			//int anyNumber = 123;
			//user.Deconstruct(out name, out int age, ref anyNumber, anyNumber);
			//Console.WriteLine($"{name} - {age}");
			//Console.WriteLine(anyNumber);


			//// упаковка и распаковка данных
			//var number = 10;
			//Console.WriteLine(number);
			//object my_number = number; // упаковка
			//Console.WriteLine(my_number);
			//var number_from_object = (int)my_number; // распаковка
			//Console.WriteLine(number_from_object);

			//// распаковка (можем распаковать только в исходный значимый тип данных)
			//var number_from_object_1 = (sbyte)my_number;
			//Console.WriteLine(number_from_object_1);

			/*
            Типи значень:

            Цілочисленні типи (byte, sbyte, short, ushort, int, uint, long, ulong)

            Типи з плаваючою комою (float, double)

            Тип decimal

            Тип bool

            Тип char

            Перерахування enum

            Структури (struct)

            Посилальні типи: (ссылочные типы данных)

            Тип object

            Тип string

            Класи (class)

            Інтерфейси (interface)

            Делегати (delegate)
            */
		}
	}
}

