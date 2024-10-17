//namespace IDisposableAfterCleanup
//{
//    using System;

//    public class ForeColor : IDisposable
//    {
//        private readonly ConsoleColor _previousColor;

//        public ForeColor(ConsoleColor foreColor)
//        {
//            _previousColor = Console.ForegroundColor;
//            Console.ForegroundColor = foreColor;
//        }

//        public void Dispose()
//        {
//            Console.ForegroundColor = _previousColor;
//        }
//    }

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
//                using (new ForeColor(ConsoleColor.Red))
//                {
//                    Console.WriteLine("oops there was an exception but I was able to survive it");
//                }
//            }

//            Console.WriteLine("My work is done...");
//        }

//        private static void DisplayWelcomeNotes()
//        {
//            using (new ForeColor(ConsoleColor.Green))
//            {
//                Console.WriteLine("Welcome to this very useful app");
//            }
//        }

//        private static void DisplayExitNotes()
//        {
//            using (new ForeColor(ConsoleColor.Green))
//            {
//                Console.WriteLine();
//                Console.WriteLine("Thanks for using this very useful app");
//                Console.WriteLine("Press enter to exit");
//                Console.ReadLine();
//            }
//        }
//    }
//}