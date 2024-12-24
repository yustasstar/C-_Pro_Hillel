using DesignPatternsExamples.Command.Interfaaces;
using System;

namespace DesignPatternsExamples.Command.Classes
{
    public class LaserPrintCommand : IPrintCommand
    {
        private LaserPrinter laser = new LaserPrinter();

        public void ExecutePrint(string Text)
        {
            Console.WriteLine("Printer: I'm hanging in the queue!");
            Console.WriteLine("Printer: now I'm going to print\n");
            laser.Print(Text);
        }
    }
}
