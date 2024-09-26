using HW_2_OOP_Principles.Instruments;
using HW_2_OOP_Principles.Product.Product;

//Task1_OOP();
Task2_OOP();

static void Task1_OOP()
{
    Product product = new Product();

    product.SetProductName();
    product.SetProductPrice();
    product.DisplayProduct();
    product.ReduceProductPrice();
    product.DisplayProduct();
}

static void Task2_OOP()
{
    List<MusicalInstrument> instruments = new List<MusicalInstrument>
    {
        new Violin(),
        new Trombone(),
        new Ukulele(),
        new Cello()
    };

    foreach (var instrument in instruments)
    {
        instrument.Show();
        instrument.Description();
        instrument.History();
        instrument.Sound();
        Console.WriteLine("--------------------------------------------"); 
    }
}