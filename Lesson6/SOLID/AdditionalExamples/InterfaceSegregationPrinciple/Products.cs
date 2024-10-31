using InterfaceSegregationPrinciple.Device;

namespace InterfaceSegregationPrinciple
{
    class Products
    {
        public string GetCellPhone(int id, int weight, int stock, string caseMaterial)
        {
            var smartphone = new Smartphone
            {
                Id = id,
                Weight = weight,
                Stock = stock,
                CaseMaterial = caseMaterial,
            };

            return smartphone.GetFeatures();
        }

        public string GetPersonalComputer(int id, int weight, int stock, string coolingSystem, string caseFormFactor)
        {
            var laptop = new Laptop
            {
                Id = id,
                Weight = weight,
                Stock = stock,
                CoolingSystem = coolingSystem,
                CaseFormFactor = caseFormFactor,
            };

            return laptop.GetFeatures();
        }
    }
}
