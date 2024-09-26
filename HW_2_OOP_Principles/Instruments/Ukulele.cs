namespace HW_2_OOP_Principles.Instruments
{
    internal class Ukulele : MusicalInstrument
    {
        private static readonly string _name = "Ukulele";
        private static readonly string _description = $"{_name} is a small four-stringed Hawaiian instrument.";
        private static readonly string _history = $"{_name} was developed on the basis of Portuguese instruments in the 19th century.";

        public Ukulele() : base(_name, _description, _history) { }
    }
}
