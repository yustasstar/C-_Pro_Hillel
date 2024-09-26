namespace HW_2_OOP_Principles.Product.Product
{
    internal class Money
    {
        private int _wholePart;
        private int _cents;
        public readonly int _maxPrice = 999999;
        private readonly string _currency = "$";

        public Money(int wholePart, int cents)
        {
            WholePart = wholePart;
            Cents = cents;
        }

        public int WholePart
        {
            get => _wholePart;
            set
            {
                if (value >= 0 && value <= _maxPrice)
                    _wholePart = value;
                else
                    throw new ArgumentException($"WholePart cannot be negative or over maxPrice = {_maxPrice}!");
            }
        }

        public int Cents
        {
            get => _cents;
            set
            {
                if (value >= 0 && value < 100)
                {
                    _cents = value;
                }
                else
                    throw new ArgumentException("Invalid input. Cents must be integer between 0 and 99!");
            }
        }

        public void SetMoney(int wholePart, int cents)
        {
            WholePart = wholePart;
            Cents = cents;
        }

        public void ReduceMoney()
        {
            Console.WriteLine("Enter the whole part of the price reduction:");
            if (!int.TryParse(Console.ReadLine(), out int reduceWholePart) || reduceWholePart < 0 || reduceWholePart > _maxPrice)
            {
                throw new ArgumentException($"reduceWholePart should be positive integer less then maxPrice = {_maxPrice}!");
            }

            Console.WriteLine("Enter the cents part of the price reduction:");
            if (!int.TryParse(Console.ReadLine(), out int reduceCents) || reduceCents < 0 || reduceCents >= 100)
            {
                throw new ArgumentException("Invalid input. Cents must be integer between 0 and 99!");
            }

            int totalCents = _wholePart * 100 + _cents - (reduceWholePart * 100 + reduceCents);
            if (totalCents < 0)
            {
                throw new ArgumentException("The price cannot be negative!");
            }

            WholePart = totalCents / 100;
            Cents = totalCents % 100;
        }

        public void DisplayMoney()
        {
            Console.WriteLine($"Price: {_currency} {_wholePart}.{_cents:D2}");
            Console.WriteLine("---------------------------");
        }
    }
}
