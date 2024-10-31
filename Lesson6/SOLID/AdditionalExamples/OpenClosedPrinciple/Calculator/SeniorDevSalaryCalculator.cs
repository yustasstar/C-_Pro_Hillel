using OpenClosedPrinciple.Model;

namespace OpenClosedPrinciple.Calculator
{
    public class SeniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDevSalaryCalculator(DeveloperReport report)
            : base(report)
        {
        }

        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.8;
    }
}
