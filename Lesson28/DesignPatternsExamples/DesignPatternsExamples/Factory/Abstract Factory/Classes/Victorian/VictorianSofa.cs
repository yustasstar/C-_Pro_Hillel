using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Victorian
{
    public class VictorianSofa : ISofa
    {
        public string Name => "Victorian sofa";

        public string GetPurpose(string description)
        {
            return description;
        }
    }
}
