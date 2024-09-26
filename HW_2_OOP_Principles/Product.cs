namespace HW_2_OOP_Principles
{
    internal class Product
    {
        public string? Name { get; set; } = "noname";
        private readonly Money _price;

        public Product()
        {
            _price = new Money(0, 0);
        }

        public void SetProductName()
        {
            Console.WriteLine("Enter the product name:");
            Name = Console.ReadLine();
        }

        public void SetProductPrice()
        {
            Console.WriteLine($"Enter the whole part of the '{Name}' price:");
            if (!int.TryParse(Console.ReadLine(), out int wholePart) || wholePart < 0)
            {
                throw new ArgumentException("WholePart cannot be negative!");
            }

            Console.WriteLine($"Enter the cents part of the '{Name}' price:");
            if (!int.TryParse(Console.ReadLine(), out int cents) || cents < 0 || cents >= 100)
            {
                throw new ArgumentException("Invalid input. Cents must be between 0 and 99!");
            }

            _price.SetMoney(wholePart, cents);
        }
        public void ReducePrice()
        {
            _price.ReduceMoney();
            Console.WriteLine("Price after reduction:");
        }

        public void DisplayProduct()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Product: {Name}");

            _price.DisplayMoney();
        }
    }
}