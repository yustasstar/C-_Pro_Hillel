using DesignPatternsExamples.Factory.Abstract_Factory.Enums;
using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Default
{
    public class DefaultFurniture : IFurniture
    {
        private readonly FurnitureType _furnitureType;

        public DefaultFurniture(FurnitureType furnitureType)
        {
            _furnitureType = furnitureType;
        }

        public IBaseProduct Create()
        {
            switch (_furnitureType)
            {
                case FurnitureType.Armchair:
                    return new DefaultArmchair();
                case FurnitureType.Sofa:
                    return new DefaultSofa();
                default:
                    case FurnitureType.Table:
                        return new DefaultTable();
            }
        }
    }
}
