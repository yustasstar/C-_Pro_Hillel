//using System;

//namespace InterfaceSegregationPrinciple
//{
//    class Program
//    {
//        private static void Main()
//        {
//            Console.WriteLine("---Interface Segregation Principle---");

//            Console.WriteLine("Select a product: ");
//            Console.WriteLine("1. Laptop");
//            Console.WriteLine("2. Smart-phone");

//            var option = Convert.ToInt32(Console.ReadLine());

//            var products = new Products();
//            var product = string.Empty;

//            switch (option)
//            {
//                case 1:
//                    product = products.GetPersonalComputer(123, 10, 123456789, "Zalman", "Tower");
//                    break;
//                case 2:
//                    product = products.GetCellPhone(234, 5, 987654321, "Aluminium");
//                    break;
//            }

//            Console.WriteLine("\n---Product---\n");
//            Console.WriteLine($"Selected product:\n{product}");
//        }
//    }
//}
