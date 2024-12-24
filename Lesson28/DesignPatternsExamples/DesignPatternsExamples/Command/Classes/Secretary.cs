using DesignPatternsExamples.Command.Interfaaces;

namespace DesignPatternsExamples.Command.Classes
{
    public class Secretary
    {
        public string Document = "Test document text.";
        public IPrintCommand Command;

        public Secretary()
        {
            PrintDocument();
        }

        public void PrintDocument()
        {
            Command = new InkPrintCommand();
            Command.ExecutePrint(Document);

            Command = new LaserPrintCommand();
            Command.ExecutePrint(Document);

            return;
        }
    }
}
