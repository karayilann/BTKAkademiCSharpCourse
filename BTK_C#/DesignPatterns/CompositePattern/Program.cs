using System.Collections;


Employee ceo = new Employee("John");
Employee headSales = new Employee("Robert");
Employee headMarketing = new Employee("Michel");

ceo.AddSubordinate(headSales);
ceo.AddSubordinate(headMarketing);

Employee marketingEmployee = new Employee("Laura");
headMarketing.AddSubordinate(marketingEmployee);

Contractor contractor1 = new Contractor { Name = "Sam" };
headSales.AddSubordinate(contractor1);

foreach (Employee manager in ceo)
{
    Console.WriteLine("Person Name " + manager.Name + " Ceo : " + ceo.Name);
    foreach (IPerson employee in manager)
    {
        Console.WriteLine("Employee Name " +employee.Name + " Head : " + manager.Name);
    }
}


interface IPerson
{
    string Name { get; set; }
}

class Contractor :IPerson
{
    public string Name { get; set; }
   
}

class Employee : IPerson,IEnumerable<IPerson>
{
    List<IPerson> _subordinates = new List<IPerson>();

    public void AddSubordinate(IPerson person)
    {
        _subordinates.Add(person);
    }

    public void RemoveSubordinate(IPerson person)
    {
        _subordinates.Remove(person);
    }

    public IPerson GetSubordinate(int index)
    {
        return _subordinates[index];
    }

    public string Name { get; set; }
    public Employee(string name)
    {
        Name = name;
    }

    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach (var subordinate in _subordinates)
        {
            yield return subordinate;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}