
CustomerManager customerManager = new CustomerManager();
customerManager.Save();

public class CustomerManager
{
    public void Save()
    {
        ILogger dbLogger = new LoggerFactory().GetLogger("database");
        ILogger fileLogger = new LoggerFactory().GetLogger("file");
        ILogger defaultLogger = new LoggerFactory().GetLogger();
        dbLogger.Log();
        fileLogger.Log();
        defaultLogger.Log();

        Console.WriteLine("*******************************************");
        Console.WriteLine("\n");

        //Dependency Injection yapılarak newlenen logger nesnesinden kurtulabiliriz.
        var logger = new LoggerFactory().GetLogger(new DatabaseLogger());
    }
}

public class LoggerFactory : ILoggerFactory
{
    private ILogger _chosenLogger;

    public ILogger GetLogger()
    {
       return new MKLogger();
    }

    public ILogger GetLogger(string loggerType)
    {
        if (loggerType.ToLower() == "database")
        {
            return new DatabaseLogger();
        }
        else if (loggerType.ToLower() == "file")
        {
            return new FileLogger();
        }
        else
        {
            return new MKLogger();
        }
    }

    public ILogger GetLogger(ILogger logger)
    {
        _chosenLogger = logger;
        _chosenLogger.Log();
        return _chosenLogger;
    }


}

public interface ILoggerFactory
{
}

public interface ILogger
{ 
    void Log();
}


public class DatabaseLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged to Database by " + this);
    }
}

public class FileLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged to File by " + this);
    }
}


public class MKLogger : ILogger 
{ 
    public void Log()
    {
        Console.WriteLine("Default logger is : " + this );
    }
}