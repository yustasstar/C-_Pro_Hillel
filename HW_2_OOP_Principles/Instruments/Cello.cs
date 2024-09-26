namespace HW_2_OOP_Principles.Instruments
{
    internal class Cello : MusicalInstrument
    {
        private static readonly string _name = "Cello";
        private static readonly string _description = $"{_name} is a stringed instrument similar to a violin, but larger in size.";
        private static readonly string _history = $"{_name} appeared in the 16th century in Italy.";

        public Cello() : base(_name, _description, _history) { }
    }
}
