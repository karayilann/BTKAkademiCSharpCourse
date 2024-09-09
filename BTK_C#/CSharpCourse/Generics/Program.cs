

Utilities utilities = new Utilities();
List<string> nameList = utilities.BuildList("Ali", "Efe", "Mert");

foreach (var name in nameList)
{
    Console.WriteLine(name);
}
Console.WriteLine(nameList.Count);
Console.ReadLine();

List<Customer> customerList = utilities.BuildList(new Customer{FirstName = "Muhammet"}, new Customer{FirstName = "Hamit"});
foreach (var customer in customerList)
{
    Console.WriteLine(customer.FirstName);
}

Console.ReadLine();


class Customer : IEntitiy
{
    public string FirstName { get; set; }
}

class Product :IEntitiy
{

}


class Utilities
{
    public List<T> BuildList<T>(params T[] items)
    {
        return new List<T>(items);
    }
}


//Databaseleri kapsayan bir interface olduğunu varsayıyoruz
interface IEntitiy
{
    
}


interface IRepository<T> where T:class, IEntitiy,new()
{
    // where T:class buna generic constrains denir bu sayede sadece belirli tipleri generic olarak işaretleriz

    /*
        Sınıflar (Classes): Herhangi bir kullanıcı tanımlı sınıf (public class MyClass { ... }).
        
        Diziler (Arrays): Herhangi bir dizi türü (int[], string[], MyClass[], vb.).
        
        Delegate Türleri (Delegates): Herhangi bir delege türü (Action, Func<T>, vb.).
        
        Arayüzler (Interfaces): Herhangi bir arayüz türü (IList<T>, IDisposable, vb.).
        
        String: string özel bir referans türüdür.
        
        Collections: Referans türü olarak değerlendirilen koleksiyon türleri (List<T>, Dictionary<TKey, TValue>, vb.).
        
        Diğer Referans Türleri: object ve dynamic gibi diğer referans türleri. 

        Değer türleri (value types) ve yapılandırılmış (struct) türler bu kısıtlamaya uymaz. 
        Bu türlere örnek olarak int, double, bool, DateTime, ve struct ile tanımlanmış özel türler verilebilir.
     */

    // , new() komutunu da yazarsak sadece newlenebilir tipleri kabul eder. Ve her zaman en sonda yazılmalı
    
    // :IEntitiy kodu ile sadece IEntitiy interfacesinden implemente edenleri type olarak kabul edebilir. Sadece interface değil classlarda da geçerli
    
    // Eğer sadece değer tipler verebilmek isterse :struct yazarız. Bunlar :  int, double, bool, DateTime, ve struct olabilir.

    List<T> GetAll();
    void GetProduct(T entitiy);
    void Delete(T entitiy);
    void Add(T entitiy);
    void Update(T entitiy);
    T GetById(int id);

}


interface ICustomerDal:IRepository<Customer>
{
    
}


interface IProductDal: IRepository<Product>
{
    
}


// Doğrudan IRepositoryden de alabilirdik fakat Customere özel bir kod ekleyeceğimiz zaman hepsinde implemente etmek zorunlu olurdu.

class CustomerDal:ICustomerDal
{
    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public void GetProduct(Customer entitiy)
    {
        throw new NotImplementedException();
    }

    public void Delete(Customer entitiy)
    {
        throw new NotImplementedException();
    }

    public void Add(Customer entitiy)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer entitiy)
    {
        throw new NotImplementedException();
    }

    public Customer GetById(int id)
    {
        throw new NotImplementedException();
    }
}

class ProductDal : IProductDal
{
    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public void GetProduct(Product entitiy)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entitiy)
    {
        throw new NotImplementedException();
    }

    public void Add(Product entitiy)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entitiy)
    {
        throw new NotImplementedException();
    }

    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }
}
