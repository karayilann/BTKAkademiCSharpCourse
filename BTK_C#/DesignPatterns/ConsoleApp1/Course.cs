using SingletonDesignPattern;

//CustomerManager.CreateAsSingleton().Save();
//TestSingleton.Instance.Save();




class CustomerManager
{
    private static CustomerManager _customerManager;
    static object _lockObject = new object();

    public CustomerManager()
    {

    }

    public static CustomerManager CreateAsSingleton()
    {
        //if(_customerManager == null)
        //{
        //    _customerManager = new CustomerManager();
        //}
        //return _customerManager ?? (_customerManager = new CustomerManager());
        //return _customerManager ??= new CustomerManager();

        // Lock mekanizması bir kodun oluşturulan örneğinin aynı anda birden fazla thread tarafından oluşturulmasını engeller.
        // Bu yapıya thread-safe denir.

        lock (_lockObject)
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
            return _customerManager;
        }

    }

    public void Save()
    {
        Console.WriteLine("Saved");
    }

    public void TestSingleton(string threadName)
    {
        for (int i = 0; i < 10; i++)
        {
            var instance = CustomerManager.CreateAsSingleton();
            Console.WriteLine($"{threadName}: CustomerManager Instance HashCode: {instance.GetHashCode()}");
        }
    }
}


