using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Default
{
    public class DefaultTable : ITable
    {
        public string Name => "Default table";

        public string GetPurpose()
        {
            return "To put";
        }
    }
}
