

using System.Reflection;
using System.Reflection.Metadata;

DortIslem dortIslem = new DortIslem(2, 2);
dortIslem.Topla2(); // Constructordaki değerleri kullanır.
dortIslem.Topla(3,4);

//Console.WriteLine(dortIslem.Topla2());
//Console.WriteLine(dortIslem.Topla(3, 4));

// Aşağıdaki ve yukarıdaki iki işlem arasındaki fark reflectionlar derleme esnasında çalıştırılır ve bu nedenle performans kaybına neden olur.

var tip = typeof(DortIslem);
DortIslem dortislem = (DortIslem)Activator.CreateInstance(tip);

//Console.WriteLine("Reflection result 1 =  "+ dortislem.Topla2());
//Console.WriteLine(dortislem.Topla(3,4));

var instance = Activator.CreateInstance(tip,6,7);
var Method = instance.GetType().GetMethod("Topla2").Invoke(instance,null);
Console.WriteLine(Method);
Console.WriteLine("-----------------------------------------");


List<MethodInfo> methodInfos = tip.GetMethods().ToList();

foreach (var methods in methodInfos)
{
    Console.WriteLine( "Method adı : " + methods.Name);
    foreach (var parameter in methods.GetParameters())
    {
        Console.WriteLine("Parametre adı : " + parameter.Name);
    }

    foreach (var customAttribute in methods.GetCustomAttributes())
    {
        Console.WriteLine("Attribute adı : " + customAttribute.GetType().Name);
    }

}



Console.ReadLine();


public class DortIslem
{
    private int _sayi1;
    private int _sayi2;

    public DortIslem(int sayi1,int sayi2)
    {
        _sayi1 = sayi1;
        _sayi2 = sayi2;
    }

    public DortIslem()
    {

    }

    public int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }

    public int Carp(int sayi1, int sayi2)
    {
        return sayi1 * sayi2;
    } 
    
    public int Topla2()
    {
        return _sayi1 + _sayi2;
    }

    public int Carp2()
    {
        return _sayi1 * _sayi2;
    }


}