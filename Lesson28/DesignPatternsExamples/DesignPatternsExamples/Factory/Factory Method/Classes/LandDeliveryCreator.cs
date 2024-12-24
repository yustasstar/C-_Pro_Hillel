using DesignPatternsExamples.Factory.Factory_Method.Interfaces;

namespace DesignPatternsExamples.Factory.Factory_Method.Classes
{
    public class LandDeliveryCreator : Creator
    {
        public override IDelivery CreateDelivery()
        {
            return new LandDelivery();
        }
    }
}
