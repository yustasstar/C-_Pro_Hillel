using DesignPatternsExamples.Command.Interfaaces;
using System;

namespace DesignPatternsExamples.Command.Classes
{
    public class LaserPrinter : IPrinter
    {
        public void Print(string Text)
        {
            Console.WriteLine("Printer: I have a LaserPrinter and I'm printing now\n");
            Console.WriteLine(Text);
        }
    }
}
