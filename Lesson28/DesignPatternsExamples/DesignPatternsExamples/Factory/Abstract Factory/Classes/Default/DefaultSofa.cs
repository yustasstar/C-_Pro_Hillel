using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Default
{
    public class DefaultSofa : ISofa
    {
        public string Name => "Default sofa";

        public string GetPurpose(string description)
        {
            return "To lay with comforts: " + description;
        }
    }
}
