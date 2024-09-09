

Customer customer = new Customer
{
    Name = "Muhammet",
    LastName = "Karayılan",
    Age = 25
};

//Customer customer2 = (Customer)customer.Clone();
//Customer customer2 = customer.Clone() as Customer;
var customer2 = customer.Clone();
customer2.Name = "Ahmet";
Console.WriteLine(customer.Name);
Console.WriteLine(customer2.Name);
Console.ReadLine();

public abstract class Person
{
    public abstract Person Clone();

    public string Name { get; set; }
    public int Age { get; set; }
    public string LastName { get; set; }

}

public class Customer : Person
{
    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}

public class Employee : Person
{
    public decimal Salary { get; set; }
    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}

