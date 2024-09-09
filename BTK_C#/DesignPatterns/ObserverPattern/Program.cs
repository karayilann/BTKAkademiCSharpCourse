
ProductManager productManager = new ProductManager();
CustomerObserver customerObserver = new CustomerObserver();
EmployeeObserver employeeObserver = new EmployeeObserver();
productManager.Attach(customerObserver);
productManager.Attach(employeeObserver);
productManager.UpdatePrice();
productManager.Detach(employeeObserver);



class ProductManager
{
    List<Observer> observers = new List<Observer>();
    public void UpdatePrice()
    {
        Console.WriteLine("Product price updated");
        Notify();
    }

    public void Attach(Observer observer)
    {
        observers.Add(observer);
        Console.WriteLine("Observer added " + observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
        Console.WriteLine("Observer removed " + observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }

}

abstract class Observer
{
    public abstract void Update();
}

class CustomerObserver : Observer
{
    public override void Update()
    {
        Console.WriteLine("Customer notified");
    }
}

class EmployeeObserver : Observer
{
    public override void Update()
    {
        Console.WriteLine("Employee notified");
    }
}