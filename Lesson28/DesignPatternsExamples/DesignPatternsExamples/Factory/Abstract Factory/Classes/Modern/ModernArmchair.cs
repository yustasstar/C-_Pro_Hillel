using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Modern
{
    public class ModernArmchair : IArmchair
    {
        public string Name => "Modern armchair";

        public string GetPurpose(int numbersOfHandles)
        {
            return "To sit and hold " + numbersOfHandles.ToString() + " handles";
        }
    }
}
