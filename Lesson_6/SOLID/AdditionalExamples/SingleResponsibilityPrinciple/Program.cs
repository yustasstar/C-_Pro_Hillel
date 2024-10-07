//using System;
//using SingleResponsibilityPrinciple.Validation;

//namespace SingleResponsibilityPrinciple
//{
//    class Program
//    {
//        private static void Main()
//        {
//            Console.WriteLine("---Single Responsibility Principle---");

//            var validation = new Validation.Validation(new ValidationText(), new ValidationEmail(), new ValidationNumber());

//            Console.Write("Enter the name: ");
//            var name = Console.ReadLine();

//            Console.Write("Enter the last name: ");
//            var lastName = Console.ReadLine();

//            Console.Write("Enter the email: ");
//            var email = Console.ReadLine();

//            Console.Write("Enter the age number: ");
//            var age = Console.ReadLine();

//            var result = validation.ValidateForm(name, lastName, email, age);
//            Console.WriteLine(result);
//        }
//    }
//}
