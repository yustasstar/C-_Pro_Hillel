using DesignPatternsExamples.Factory.Factory_Method.Interfaces;

namespace DesignPatternsExamples.Factory.Factory_Method.Classes
{
    public class WaterDelivery : IDelivery
    {
        public string GetDeliveryType()
        {
            return "Will deliver by water";
        }
    }
}
