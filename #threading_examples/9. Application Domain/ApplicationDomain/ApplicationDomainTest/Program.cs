using System;
using System.Reflection;

namespace ApplicationDomainTest
{
    public class Demo
    {
        public Demo(int val1, int val2)
        {
            Console.WriteLine("Из сборки {0} вызван конструктор со значениями {1}, {2} в домене {3}",
                  Assembly.GetExecutingAssembly().GetName().Name, val1, val2, AppDomain.CurrentDomain.FriendlyName);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Из сборки {0} вызван метод Main в домене {1}",
                 Assembly.GetExecutingAssembly().GetName().Name, AppDomain.CurrentDomain.FriendlyName);
            Demo obj = new Demo(10, 15);
            Console.ReadLine();
        }
    }
}
