


ProductManager productManager = new ProductManager(new Factory1());
ProductManager productManager2 = new ProductManager(new Factory2());
productManager.GetAllData();
productManager2.GetAllData();



public abstract class Logging
{
    public abstract void Log(string message);
}

public abstract class Caching
{
    public abstract void Cache(string data);
}


public class Log4NetLogging : Logging
{
    public override void Log(string message)
    {
        Console.WriteLine("Log4Net: " + message);
    }
}

public class NLogging : Logging
{
    public override void Log(string message)
    {
        Console.WriteLine("NLogging: " + message);
    }
}


public class MemCaching : Caching
{
    public override void Cache(string data)
    {
        Console.WriteLine("MemCaching: " + data);
    }
}

public class RedisCaching : Caching
{
    public override void Cache(string data)
    {
        Console.WriteLine("RedisCaching: " + data);
    }
}


public abstract class CrossCuttingConcernsFactory
{
    public abstract Logging CreateLogger();
    public abstract Caching CreateCaching();
}

public class Factory1 : CrossCuttingConcernsFactory
{
    public override Logging CreateLogger()
    {
        return new Log4NetLogging();
    }

    public override Caching CreateCaching()
    {
        return new MemCaching();
    }
}

public class Factory2 : CrossCuttingConcernsFactory
{
    public override Logging CreateLogger()
    {
        return new NLogging();
    }

    public override Caching CreateCaching()
    {
        return new RedisCaching();
    }
}


public class ProductManager
{
    private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;

    Logging _logging;
    Caching _caching;

    public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
    {
        _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
        _logging = _crossCuttingConcernsFactory.CreateLogger();
        _caching = _crossCuttingConcernsFactory.CreateCaching();
    }

    public void GetAllData()
    {
        _logging.Log("Logged!");
        _caching.Cache("Data Cached!");
        Console.WriteLine("Products listed!");
    }
}