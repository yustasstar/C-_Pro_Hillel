namespace HW_2_OOP_Principles.Instruments
{
    internal class Trombone : MusicalInstrument
    {
        private static readonly string _name = "Trombone";
        private static readonly string _description = $"{_name} is a wind instrument with a movable curtain mechanism.";
        private static readonly string _history = $"{_name} originated in the XV century, it comes from the sacqueboute family.";

        public Trombone() : base(_name, _description, _history) { }
    }
}
