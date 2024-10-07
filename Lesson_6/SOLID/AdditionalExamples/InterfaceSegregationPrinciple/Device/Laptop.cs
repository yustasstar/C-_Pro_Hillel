using InterfaceSegregationPrinciple.DeviceInterface;

namespace InterfaceSegregationPrinciple.Device
{
	class Laptop : IProduct, IPersonalComputer
	{
		public int Id { get; set; }

		public double Weight { get; set; }

		public int Stock { get; set; }

		public string CoolingSystem { get; set; }

		public string CaseFormFactor { get; set; }

		public string GetFeatures()
		{
			var product = string.Empty;

			product += "Product name: Laptop\n";
			product += $"Id: {Id}\n";
			product += $"Weight: {Weight}\n";
			product += $"Stock: {Stock}\n";
			product += $"Cooling System: {CoolingSystem}";
			product += $"Case Form Factor: {CaseFormFactor}";

			return product;
		}
	}
}
