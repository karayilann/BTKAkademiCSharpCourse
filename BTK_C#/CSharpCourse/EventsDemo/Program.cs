
using EventsDemo;

Product harddisk = new Product(50, "Hard Disk");

harddisk.StockControlEvent += Harddisk_StockControlEvent;

void Harddisk_StockControlEvent()
{
    Console.WriteLine("harddisk azalıyor");
    Console.ReadLine();
    harddisk.AddProduct(harddisk,50);
    Console.WriteLine(harddisk.StockCount);
    Console.ReadLine();
}

for (int i = 0; i < float.PositiveInfinity; i++)
{
    harddisk.Sell(3);
    Console.ReadLine();
}


