using DesignPatternsExamples.Factory.Abstract_Factory.Enums;
using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Victorian
{
    public class VictorianFurniture : IFurniture
    {
        private readonly FurnitureType _furnitureType;

        public VictorianFurniture(FurnitureType furnitureType)
        {
            _furnitureType = furnitureType;
        }

        public IBaseProduct Create()
        {
            switch (_furnitureType)
            {
                case FurnitureType.Armchair:
                    return new VictorianArmchair();
                case FurnitureType.Sofa:
                    return new VictorianSofa();
                default:
                    case FurnitureType.Table:
                        return new VictorianTable();
            }
        }
    }
}
