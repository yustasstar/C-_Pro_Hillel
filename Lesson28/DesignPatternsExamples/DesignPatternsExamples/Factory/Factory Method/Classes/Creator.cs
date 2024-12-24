using DesignPatternsExamples.Factory.Factory_Method.Interfaces;

namespace DesignPatternsExamples.Factory.Factory_Method.Classes
{
    public abstract class Creator
    {
        public abstract IDelivery CreateDelivery();

        public string CreateDeliveryAndGetName()
        {
            IDelivery delivery = CreateDelivery();
            var result = "Created delivery type:  " + delivery.GetDeliveryType();

            return result;
        }
    }
}
