using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Modern
{
    public class ModernTable : ITable
    {
        public string Name => "Modern table";

        public string GetPurpose()
        {
            return "To put";
        }
    }
}
