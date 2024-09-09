
using System.ComponentModel.DataAnnotations;

CustomerDal _customerDal = new CustomerDal();

_customerDal.Add(new Customer
{
    Age = 12,
    Id = 1,
    LastName = "Efe"
});

[ToTable("Customers")]
[ToTable("NewCustomers")]
class Customer
{
    public int Id { get; set; }

    [RequiredProperty] public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Age {get; set; }
}


class CustomerDal
{
    [Obsolete("Don't use Add, instead use AddNew Method")] //bu attribute yenisi yazılan methodlar için kullanılır parametre ile hata da verdirir.
    public void Add(Customer customer)
    {
        Console.WriteLine("{0} ,{1} ,{2} ,{3}", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        Console.ReadLine();
    } 
    
    public void AddNew(Customer customer)
    {
        Console.WriteLine("{0} ,{1} ,{2} ,{3}", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        Console.ReadLine();
    }
}

[AttributeUsage(AttributeTargets.Property,AllowMultiple = true)] // Bu attribute nerede kullanacağını belirliyorsun

//[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)] ==>> Bu şekilde ise birden fazta türe atama yapabilirsin

//[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)] ==>> AllowMultiple yöntemi ile birden fazla kullanımına izin veririz
// Bunu yapmaktaki amaç bazı kısımlarda attributelerin aldığı değerler birden fazla olabilir. Bu nedenle birden fazla kullanabiliriz

class RequiredPropertyAttribute : Attribute
{



}


[AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
class ToTableAttribute : Attribute
{
    private string _tableName;

    public ToTableAttribute(string tableName)
    {
        _tableName = tableName;
    }

}


