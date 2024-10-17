using OpenClosedPrinciple.Model;

namespace OpenClosedPrinciple.Calculator
{
	public class MiddleDevSalaryCalculator : BaseSalaryCalculator
	{
		public MiddleDevSalaryCalculator(DeveloperReport developerReport)
			: base(developerReport)
		{
		}

		public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
	}
}
