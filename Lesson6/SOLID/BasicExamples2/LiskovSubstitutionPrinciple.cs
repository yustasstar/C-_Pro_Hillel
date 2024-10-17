namespace Lesson6.SOLID.BasicExamples2
{
	// Принцип підстановки Лисков(Liskov Substitution Principle) є деяким посібником зі створення ієрархій успадкування.
	// Початкове визначення даного принципу, яке було дано Барбарою Лисков у 1988 році, виглядало так:

	// Якщо кожного об'єкта o1 типу S існує об'єкт o2 типу T, такий, що з будь-якої програми P, визначеної термінах T,
	// поведінка P не змінюється при заміні o2 на o1, то є підтипом T.
	// Тобто іншими словами, клас S може вважатися підкласом T, якщо заміна об'єктів T на об'єкти S не призведе до зміни роботи програми.

	// Загалом цей принцип можна сформулювати так:
	// Повинна бути можливість замість базового типу підставити будь-який підтип.

	// Фактично принцип підстановки Лиск допомагає чіткіше сформулювати ієрархію класів,
	// визначити функціонал для базових і похідних класів і уникнути можливих проблем при застосуванні поліморфізму.

	public abstract class Employee
	{
		public virtual string GetWorkDetails(int id)
		{
			return "Base Work";
		}

		public virtual string GetEmployeeDetails(int id)
		{
			return "Base Employee";
		}
	}

	public class SeniorEmployee : Employee
	{
		public override string GetWorkDetails(int id)
		{
			return "Senior Work";
		}

		public override string GetEmployeeDetails(int id)
		{
			return "Senior Employee";
		}
	}

	public class JuniorEmployee : Employee
	{
		// Допустим, для Junior’a отсутствует информация
		public override string GetWorkDetails(int id)
		{
			throw new NotImplementedException();
		}

		public override string GetEmployeeDetails(int id)
		{
			return "Junior Employee";

		}
	}

	// solution
	public interface IEmployee
	{
		string GetEmployeeDetails(int employeeId);
	}

	public interface IWork
	{
		string GetWorkDetails(int employeeId);
	}

	public class SeniorEmployeeV2 : IEmployee, IWork
	{
		public string GetWorkDetails(int id)
		{
			return "Senior Work";
		}

		public string GetEmployeeDetails(int id)
		{
			return "Senior Employee";
		}
	}

	public class JuniorEmployeeV2 : IEmployee
	{
		public string GetEmployeeDetails(int id)
		{
			return "Junior Employee";

		}
	}

	public static class LiskovSubstitutionPrincipleDemo
	{
		public static void Demo()
		{
		}
	}
}

