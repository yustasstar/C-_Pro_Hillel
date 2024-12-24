using DesignPatternsExamples.Command.Interfaaces;
using System;

namespace DesignPatternsExamples.Command.Classes
{
    public class InkjetPrinter : IPrinter
    {
        public void Print(string Text)
        {
            Console.WriteLine("Printer: I have an InkJet and I'm printing now\n");
            Console.WriteLine(Text);
        }
    }
}
