using DesignPatternsExamples.Factory.Abstract_Factory.Classes.Default;
using DesignPatternsExamples.Factory.Abstract_Factory.Classes.Modern;
using DesignPatternsExamples.Factory.Abstract_Factory.Classes.Victorian;
using DesignPatternsExamples.Factory.Abstract_Factory.Enums;
using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;
using System;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes
{
    public class Furniture
    {
        public void TestFurniture()
        {
            IFurniture furniture;

            Console.WriteLine("Default furniture:");
            furniture = new DefaultFurniture(FurnitureType.Armchair);
            PrintFurniture(furniture, FurnitureType.Armchair);

            Console.WriteLine("Victorian furniture:");
            furniture = new VictorianFurniture(FurnitureType.Sofa);
            PrintFurniture(furniture, FurnitureType.Sofa);

            Console.WriteLine("Modern furniture:");
            furniture = new ModernFurniture(FurnitureType.Table);
            PrintFurniture(furniture, FurnitureType.Table);
        }

        public void PrintFurniture(IFurniture furniture, FurnitureType furnitureType)
        {
            switch (furnitureType)
            {
                case FurnitureType.Armchair:
                    Console.WriteLine(furniture.Create().Name);
                    Console.WriteLine(((IArmchair)furniture.Create()).GetPurpose(4));
                    Console.WriteLine();
                    break;
                case FurnitureType.Table:
                    Console.WriteLine(furniture.Create().Name);
                    Console.WriteLine(((ITable)furniture.Create()).GetPurpose());
                    Console.WriteLine();
                    break;
                default:
                case FurnitureType.Sofa:
                    Console.WriteLine(furniture.Create().Name);
                    Console.WriteLine(((ISofa)furniture.Create()).GetPurpose("soft touch"));
                    Console.WriteLine();
                    break;
            }
        }
    }
}
