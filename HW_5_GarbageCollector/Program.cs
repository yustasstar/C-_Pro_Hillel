using HW_5_GarbageCollector;

using (Play play = new Play("Hamlet", "William Shakespeare", "Tragedy", 1603))
{
    play.Read();
    play.Update(authorFullName: "Ivanov Vasyliy", year: 999);
    play.Read();
}
Console.WriteLine("-------------------------------------");

Play play2 = new Play("Othello", "William Shakespeare", "Tragedy", 1604);
play2.Read();
play2.Update(authorFullName: "Name Updated", title: "New Title");
play2.Read();

play2.Dispose();
play2.Read();
Console.WriteLine("**************************************");

using (Shop shop = new Shop("Good Market", "123 Main St", "Grocery"))
{
    shop.Read();
    shop.Update(shopName: "Shop Name Updated", address: "New Address");
    shop.Read();
}
Console.WriteLine("-------------------------------------");

Shop shop2 = new Shop("Hardware Hub", "456 Industrial Rd", "Hardware");
shop2.Read();
shop2.Update(shopName: "Shop Name Updated", address: "New Address");
shop2.Read();

shop2.Dispose();
shop2.Read();