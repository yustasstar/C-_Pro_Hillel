namespace Lesson6.SOLID.BasicExamples2
{
	// Принцип відкритості/закритості (Open/Closed Principle) можна сформулювати так:
	// Сутність програми повинна бути відкрита для розширення, але закрита для зміни.

	public class EmployeeV2
	{
		public int ID { get; set; }
		public string FullName { get; set; }

		public bool Add(EmployeeV2 emp)
		{
			return true;
		}
	}

	// incorrect implementation
	public class EmployeeReport
	{
		public string TypeReport { get; set; }

		public void GenerateReport(EmployeeV2 em)
		{
			if (TypeReport == "CSV")
			{
				// Генерация отчета в формате CSV
			}

			if (TypeReport == "PDF")
			{
				// Генерация отчета в формате PDF
			}
		}
	}

	//
	public interface IEmployeeReport
	{
		void GenerateReport(EmployeeV2 em);
	}

	public class EmployeeCsvReport : IEmployeeReport
	{
		public void GenerateReport(EmployeeV2 em)
		{
			// 
		}
	}

	public class EmployeePdfReport : IEmployeeReport
	{
		public void GenerateReport(EmployeeV2 em)
		{
			// 
		}
	}

	public static class OpenClosedPrincipleDemo
	{
		public static void Demo()
		{
		}
	}
}

