using HW_2_OOP_Principles.Instruments;
using HW_2_OOP_Principles.Product.Product;

//HW_2_OOP_Principles: 
Task1_OOP();
Task2_OOP();
Task3_OOP();

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

static void Task3_OOP()
{
    Console.WriteLine("Please enter the integer number to convert:");
    if (!int.TryParse(Console.ReadLine(), out int numberToConvert))
    {
        throw new ArgumentException("Invalid input. Please enter a valid integer number.");
    }
    DecimalNumber number = new(numberToConvert);

    Console.WriteLine($@"
        Decimal number = {numberToConvert} 
        Binary number = {number.ToBinary()}
        Octal number = {number.ToOctal()}
        Hexadecimal number = {number.ToHexadecimal()}");
}

internal readonly struct DecimalNumber(int value)
{
    private readonly int _value = value;

    public readonly string ToBinary() => Convert.ToString(_value, 2);
    public readonly string ToOctal() => Convert.ToString(_value, 8);
    public readonly string ToHexadecimal() => Convert.ToString(_value, 16).ToUpper();
}