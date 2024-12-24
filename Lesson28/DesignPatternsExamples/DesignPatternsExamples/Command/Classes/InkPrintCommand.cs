using DesignPatternsExamples.Command.Interfaaces;
using System;

namespace DesignPatternsExamples.Command.Classes
{
    public class InkPrintCommand : IPrintCommand
    {
        private InkjetPrinter inkie = new InkjetPrinter();

        public void ExecutePrint(string Text)
        {
            Console.WriteLine("Printer: I'm hanging in the queue!");
            Console.WriteLine("Printer: now I'm going to print\n");
            inkie.Print(Text);
        }
    }
}
