namespace HW_2_OOP_Principles.Instruments
{
    internal class Violin : MusicalInstrument
    {
        private static readonly string _name = "Violin";
        private static readonly string _description = $"The {_name} is a stringed bowed instrument.";
        private static readonly string _history = $"The {_name} was created in Italy in the 16th century.";

        public Violin() : base(_name, _description, _history) { }
    }
}
