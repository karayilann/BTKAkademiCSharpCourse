Console.WriteLine(Topla(2,3));

Func<int, int, int> add = Topla;

Console.WriteLine(add(3,4));

Func<int> getRandomNumber = delegate()
{
    Random random = new Random();
    return random.Next(1,100);
};

Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

// Func ve actionun farkı funclar bir değer döndürmelidir.

Console.WriteLine(getRandomNumber());
Thread.Sleep(1000);
Console.WriteLine(getRandomNumber2());


Console.ReadLine();
int Topla(int num1, int num2)
{
    return num1 + num2;
}