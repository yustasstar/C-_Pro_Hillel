using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Victorian
{
    public class VictorianArmchair : IArmchair
    {
        public string Name => "Victorian armchair";

        public string GetPurpose(int numbersOfHandles)
        {
            return "To sit and hold " + numbersOfHandles.ToString() + " handles";
        }
    }
}
