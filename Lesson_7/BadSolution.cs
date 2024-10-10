//namespace IDisposableForCleanup
//{
//    using System;

//    class Program
//    {
//        static void Main()
//        {
//            DisplayWelcomeNotes();
//            DoSomeWork();
//            DisplayExitNotes();
//        }

//        private static void DoSomeWork()
//        {
//            Console.WriteLine("doing some work");

//            try
//            {
//                Console.WriteLine("and doing more work");
//                throw new Exception("Some dummy exception that we can survive");
//            }
//            catch
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("oops there was an exception but I was able to survive it");
//                Console.ForegroundColor = ConsoleColor.White;
//            }

//            Console.WriteLine("My work is done...");
//        }

//        private static void DisplayWelcomeNotes()
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Welcome to this very useful app");
//            Console.ForegroundColor = ConsoleColor.White;
//        }

//        private static void DisplayExitNotes()
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine();
//            Console.WriteLine("Thanks for using this very useful app");
//            Console.WriteLine("Press enter to exit");
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.ReadLine();
//        }
//    }
//}