//using System;
//using System.Collections.Generic;
//using OpenClosedPrinciple.Calculator;
//using OpenClosedPrinciple.Model;

//namespace OpenClosedPrinciple
//{
//    internal class Program
//    {
//        private static void Main()
//        {
//            Console.WriteLine("---Open Close Principle---\n");

//            var devCalculations = new List<BaseSalaryCalculator>
//            {
//                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
//                new MiddleDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Middle developer", HourlyRate = 20, WorkingHours = 150 }),
//                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Junior developer", HourlyRate = 30.5, WorkingHours = 180 }),
//            };

//            var calculator = new SalaryCalculator(devCalculations);
//            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");

//        }
//    }
//}
