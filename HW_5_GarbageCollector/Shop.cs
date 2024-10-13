namespace HW_5_GarbageCollector
{
    public class Shop : IDisposable
    {
        public string? ShopName { get; set; }
        public string? Address { get; set; }
        public string? ShopType { get; set; }

        private bool disposed = false;

        public Shop(string? shopName, string? address, string? shopType)
        {
            ShopName = shopName;
            Address = address;
            ShopType = shopType;
        }

        ~Shop()
        {
            Dispose(false);
            Console.WriteLine("Destructor invoked");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("GC.SuppressFinalize invoked");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("managed resources cleared");
                }
                Delete();
                Console.WriteLine("unmanaged resources cleared");
                disposed = true;
            }
        }

        public void Create(string? shopName, string? address, string? shopType)
        {
            ShopName = shopName;
            Address = address;
            ShopType = shopType;
            Console.WriteLine("Data created!");
        }

        public void Read()
        {
            Console.WriteLine($"Shop Name: {ShopName ?? "N/A"}, Address: {Address ?? "N/A"}, Type: {ShopType ?? "N/A"}");
        }

        public void Update(string? shopName = null, string? address = null, string? shopType = null)
        {
            ShopName = shopName ?? ShopName;
            Address = address ?? Address;
            ShopType = shopType ?? ShopType;
            Console.WriteLine("Data updated!");
        }

        public void Delete()
        {
            ShopName = null;
            Address = null;
            ShopType = null;
            Console.WriteLine("Data cleared!");
        }
    }

}
