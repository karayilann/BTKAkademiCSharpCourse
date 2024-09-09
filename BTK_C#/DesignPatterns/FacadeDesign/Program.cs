

CustomerManager customerManager = new CustomerManager();
customerManager.Save();


class Logging : ILogging
{
    public void Log(string message)
    {
        Console.WriteLine("Logging: " + message);
    }
}

internal interface ILogging
{
    void Log(string message);

}

class Caching : ICaching
{
    public void Cache(string message)
    {
        Console.WriteLine("Caching: " + message);
    }
}

internal interface ICaching
{
    void Cache(string message);
}

class Authorize : IAuthorize
{
    public void AuthorizeUser(string message)
    {
        Console.WriteLine("Authorize: " + message);
    }
}

internal interface IAuthorize
{
    void AuthorizeUser(string message);

}

class Validate : IValidate
{
    public void ValidateUser(string message)
    {
        Console.WriteLine("Validate : " + message);
    }
}

interface IValidate
{
    void ValidateUser(string message);

}


class CustomerManager
{
    //private IAuthorize _authorize;
    //private ICaching _caching;
    //private ILogging _logging;

    //public CustomerManager(IAuthorize authorize, ICaching caching, ILogging logging)
    //{
    //    _authorize = authorize;
    //    _caching = caching;
    //    _logging = logging;
    //}


    private CrossCuttingConcernFacade _crossCuttingConcerns;

    public CustomerManager()
    {
        _crossCuttingConcerns = new CrossCuttingConcernFacade();
    }

    public void Save()
    {
        //_logging.Log("Logged");
        //_caching.Cache("Cached");
        //_authorize.AuthorizeUser("User authorized");

        _crossCuttingConcerns.logging.Log("Logged");
        _crossCuttingConcerns.caching.Cache("Cached");
        _crossCuttingConcerns.authorize.AuthorizeUser("User Authorized");
        _crossCuttingConcerns.validate.ValidateUser("User Validated");
        Console.WriteLine("Customer saved");
    }

}


class CrossCuttingConcernFacade
{
    public IAuthorize authorize;
    public ICaching caching;
    public ILogging logging;
    public IValidate validate;

    public CrossCuttingConcernFacade()
    {
        logging = new Logging();
        caching = new Caching();
        authorize = new Authorize();
        validate = new Validate();
    }

}
