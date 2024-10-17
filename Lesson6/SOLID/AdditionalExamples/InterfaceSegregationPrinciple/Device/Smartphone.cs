using InterfaceSegregationPrinciple.DeviceInterface;

namespace InterfaceSegregationPrinciple.Device
{
	class Smartphone : IProduct, ICellPhone
	{
		public int Id { get; set; }

		public double Weight { get; set; }

		public int Stock { get; set; }

		public string CaseMaterial { get; set; }

		public string GetFeatures()
		{
			string product = string.Empty;

			product += "Product name: Smart-phone\n";
			product += $"Id: {Id}\n";
			product += $"Weight: {Weight}\n";
			product += $"Stock: {Stock}\n";
			product += $"Case Material: {CaseMaterial}\n";

			return product;
		}
	}
}
