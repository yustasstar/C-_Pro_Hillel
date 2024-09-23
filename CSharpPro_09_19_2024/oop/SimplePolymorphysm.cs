namespace CSharpPro_09_19_2024.oop
{
    // интерфейс IGraphic
    interface IGraphic
    {
        void ShowText(string text);
    }

    // класс ConsoleApp
    class ConsoleApp : IGraphic
    {
        public void ShowText(string text)
        {
            Console.WriteLine("Draw text " + text + " in console application");
        }
    }

    // класс Phone
    class Phone : IGraphic
    {
        public void ShowText(string text)
        {
            Console.WriteLine("Draw text " + text + " on the phone");
        }
    }
}
