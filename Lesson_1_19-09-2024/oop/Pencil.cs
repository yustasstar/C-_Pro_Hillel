namespace oop
{
    public class Pencil
    {
        // поля
        public string name = string.Empty;
        public decimal cost = 0m;
        public string material = string.Empty;
        public string color = string.Empty;
        public string manufacturer = string.Empty;
        // и тд

        // конструктор
        public Pencil(string name, decimal cost, string material, string color, string manufacturer)
        {
            this.name = name;
            this.cost = cost;
            this.material = material;
            this.color = color;
            this.manufacturer = manufacturer;
        }

        // методы
        public void ShowPencilInfo()
        {
            Console.WriteLine($"Name: {name}" +
                $"\nCost: {cost}" +
                $"\nMaterial: {material}" +
                $"\nColor: {color}" +
                $"\nManufacturer: {manufacturer}");
        }

        public void Draw()
        {
            Console.WriteLine($"Draw with {color} color");
        }
    }
}
