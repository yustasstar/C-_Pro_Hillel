namespace Lesson6.SOLID.BasicExamples
{
	// Problem: Класс нужно постоянно модифицировать для добавления новых возможностей.

	// Класс приходится изменять каждый раз, когда нужно добавить новый тип отчета (например, HTML-отчет).
	// Это нарушает принцип закрытости — класс должен быть открыт для расширения, но закрыт для модификации.

	public class ReportGenerator
	{
		public string GenerateReport(string reportType)
		{
			if (reportType == "PDF")
			{
				// Генерация PDF отчета
				return "PDF Report";
			}
			else if (reportType == "Excel")
			{
				// Генерация Excel отчета
				return "Excel Report";
			}
			return string.Empty;
		}
	}

	// Solution: 

	// Используем полиморфизм:
	// создадим интерфейс для разных типов отчетов и будем добавлять новые отчеты через наследование.

	public interface IReport
	{
		string Generate();
	}

	public class PdfReport : IReport
	{
		public string Generate()
		{
			return "PDF Report";
		}
	}

	public class ExcelReport : IReport
	{
		public string Generate()
		{
			return "Excel Report";
		}
	}

	public class ReportGeneratorV2
	{
		public string GenerateReport(IReport report)
		{
			return report.Generate();
		}
	}

	// Теперь, чтобы добавить новый тип отчета, нам достаточно создать новый класс,
	// реализующий интерфейс IReport, не изменяя существующий код.
}
