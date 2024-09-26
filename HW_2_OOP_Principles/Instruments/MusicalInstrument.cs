namespace HW_2_OOP_Principles.Instruments
{
    internal abstract class MusicalInstrument
    {
        private readonly string _name;
        private readonly string _description;
        private readonly string _history;

        public MusicalInstrument(string name, string description, string history)
        {
            _name = name;
            _description = description;
            _history = history;
        }

        public void Show()
        {
            Console.WriteLine($"Name of instrument: {_name}");
        }

        public void Description()
        {
            Console.WriteLine($"Description of instrument: {_description}");
        }

        public void History()
        {
            Console.WriteLine($"History of instrument: {_history}");
        }

        public void Sound()
        {
            Console.WriteLine($"Sound of instrument: {_name}");
        }
    }
}
