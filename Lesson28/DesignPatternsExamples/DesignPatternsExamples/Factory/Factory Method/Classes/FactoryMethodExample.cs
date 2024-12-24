using System;

namespace DesignPatternsExamples.Factory.Factory_Method.Classes
{
    public class FactoryMethodExample
    {
        public void TestFactoryMethod()
        {
            Console.WriteLine("App: Launched Land Delivery.");
            ClientCode(new LandDeliveryCreator());

            Console.WriteLine();

            Console.WriteLine("App: Launched Water Delivery.");
            ClientCode(new WaterDeliveryCreator());
        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I don't know the creator class, but it still works.\n" + creator.CreateDeliveryAndGetName());
        }
    }
}
