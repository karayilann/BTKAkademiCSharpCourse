using System;
using System.Collections;

//string[] cities = new string[3] { "Antep", "Urfa", "Maraş" };

#region ArrayList
/*

// Herhangi bir tip beklentisi olmadan listeye ekleme yapabiliriz.
// Fakat çağırırıken mutlaka var tipinde çağırmalıyız ki hata almayalım
// ArrayListlerde tip güvenliği yoktur her tipte eleman ekleriz
ArrayList cities = new ArrayList();

cities.Add("Ankara");
cities.Add(2);
cities.Add("Mersin");

foreach (var i in cities)
{
    Console.WriteLine(i);
    Console.ReadKey();
}

*/
#endregion

#region List
/*

// Farklı bir liste tanımlama yöntemi
List<Customer> customerList = new List<Customer>()
{
    new Customer {Name = "Ali", Address = "Antep"},
    new Customer {Name = "Ali", Address = "Mersin"}
};

Customer mami = new Customer();
mami.Name = "Mami";
mami.Address = "Diyarbakır";

customerList.Add(mami);

// Bu yöntemle listedeki tüm uygun kriterdeki elemanları kaldırır.
customerList.RemoveAll(c => c.Name == "Ali");

foreach (Customer customer in customerList)
{
Console.WriteLine($"{customer.Name} {customer.Address}");
}
Console.ReadKey();

class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }
} 

*/
#endregion

#region Dictionary
/*Dictionary<string, string> properties = new Dictionary<string, string>();

properties.Add("Name", "İsim");

Console.WriteLine(properties["Name"]);
*/
#endregion