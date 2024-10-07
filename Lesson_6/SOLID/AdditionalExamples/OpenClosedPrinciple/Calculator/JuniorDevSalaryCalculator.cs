using OpenClosedPrinciple.Model;

namespace OpenClosedPrinciple.Calculator
{
	public class JuniorDevSalaryCalculator : BaseSalaryCalculator
	{
		public JuniorDevSalaryCalculator(DeveloperReport developerReport)
			: base(developerReport)
		{
		}

		public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
	}
}
