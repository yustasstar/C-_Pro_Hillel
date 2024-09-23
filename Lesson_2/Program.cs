﻿using Lesson_2.abstractClasses;
using Lesson_2.interfaces;
using Lesson_2.objAndMethods;
using System.Text;
using Lesson_2.someStandardInterfaces;
using ThirdLesson.someStandardInterfacesV2;
using Lesson_2.oop;
using SecondLesson.oop;
namespace Lesson_2
{
    public class Program
    {
        public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string name = Console.ReadLine() ?? string.Empty;

            var myPhone = new SmartPhone("Iphone", 123.44m, 333);
            myPhone.Print();
            Console.WriteLine("------------");
            PhoneBase tempPhone = myPhone;
            tempPhone.Print();

            IGraphic graphic = new ConsoleApp();
            graphic.ShowText("Hello");
            graphic = new Phone();
            graphic.ShowText("Hello");


            Example1.StartTest();
            Example2.StartTest();
            Example3.StartTest();
            Example4.StartTest();
            Example5.StartTest();
        }
    }
}

