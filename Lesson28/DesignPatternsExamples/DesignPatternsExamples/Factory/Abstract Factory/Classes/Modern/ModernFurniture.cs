using DesignPatternsExamples.Factory.Abstract_Factory.Enums;
using DesignPatternsExamples.Factory.Abstract_Factory.Interfaces;

namespace DesignPatternsExamples.Factory.Abstract_Factory.Classes.Modern
{
    public class ModernFurniture : IFurniture
    {
        private readonly FurnitureType _furnitureType;

        public ModernFurniture(FurnitureType furnitureType)
        {
            _furnitureType = furnitureType;
        }

        public IBaseProduct Create()
        {
            switch (_furnitureType)
            {
                case FurnitureType.Armchair:
                    return new ModernArmchair();
                case FurnitureType.Sofa:
                    return new ModernSofa();
                default:
                    case FurnitureType.Table:
                        return new ModernTable();
            }
        }
    }
}
