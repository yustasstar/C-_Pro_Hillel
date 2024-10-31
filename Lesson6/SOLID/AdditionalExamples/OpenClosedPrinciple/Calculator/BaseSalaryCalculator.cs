using OpenClosedPrinciple.Model;

namespace OpenClosedPrinciple.Calculator
{
    public abstract class BaseSalaryCalculator
    {
        protected DeveloperReport DeveloperReport { get; private set; }

        protected BaseSalaryCalculator(DeveloperReport developerReport)
        {
            DeveloperReport = developerReport;
        }

        public abstract double CalculateSalary();
    }
}
