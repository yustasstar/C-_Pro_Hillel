using OpenClosedPrinciple.Calculator;

namespace OpenClosedPrinciple
{
    public class SalaryCalculator
    {
        private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;

        public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
        {
            _developerCalculation = developerCalculation;
        }

        public double CalculateTotalSalaries()
        {
            return _developerCalculation.Sum(devCalc => devCalc.CalculateSalary());
        }
    }
}
