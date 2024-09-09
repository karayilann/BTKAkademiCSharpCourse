
//PersonalCar pCar = new PersonalCar
//{
//    Make = "BMW",
//    Model = "3 Series",
//    HirePrice = 250
//};

//Console.WriteLine(pCar.HirePrice);
//SpecialOffer specialOffer = new SpecialOffer(pCar, 10);
//Console.WriteLine(specialOffer.HirePrice);

// Yeni araç oluştur
PersonalCar pCar = new PersonalCar
{
    Make = "BMW",
    Model = "3 Series",
    HirePrice = 250
};

ContractedOffer contractedOffer = new ContractedOffer(new PersonalCar { Make = "Audi", Model = "A4", HirePrice = 200 });

//contractedOffer.AddContractedCar(pCar);
contractedOffer.AddContractedCar(new PersonalCar { Make = "Audi", Model = "A4", HirePrice = 200 });
contractedOffer.AddContractedCar(new PersonalCar { Make = "Mercedes", Model = "C Class", HirePrice = 300 });
contractedOffer.AddContractedCar(new PersonalCar { Make = "Volkswagen", Model = "Passat", HirePrice = 220 });


Console.WriteLine(contractedOffer.SpecialContractSpecifications()); 




abstract class CarBase
{
    public abstract string Make { get; set; }
    public abstract string Model { get; set; }
    public abstract decimal HirePrice { get; set; }

}

class PersonalCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}

class CommercialCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}
abstract class CarDecoratorBase : CarBase
{
    CarBase _carBase;
    public CarDecoratorBase(CarBase carBase)
    {
        _carBase = carBase;
    }
}


class SpecialOffer:CarDecoratorBase
{
    private int _discountPercentage { get; set; }
    readonly CarBase _carBase;

    public SpecialOffer(CarBase carBase, int discountPercentage) : base(carBase)
    {
        _carBase = carBase;
        _discountPercentage = discountPercentage;
    }
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice
    {
        get => _carBase.HirePrice -=  _carBase.HirePrice * _discountPercentage /100;
        set
        {

        }
    }
}


class ContractedOffer : CarDecoratorBase
{
    CarBase _carBase;
    private int _discountPercentage { get; set; }

    List<CarBase> _contractedCars = new List<CarBase>();

    public ContractedOffer(CarBase carBase, int discountPercentage = 0) : base(carBase)
    {
        _carBase = carBase;
        AddContractedCar(carBase);
        _discountPercentage = discountPercentage;
    }

    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice
    {
        get => _carBase.HirePrice;
        set => _carBase.HirePrice = value;
    }

    public void AddContractedCar(CarBase car)
    {
        _contractedCars.Add(car);
    }

    public decimal SpecialContractSpecifications()
    {
        decimal totalHirePrice = _contractedCars.Sum(car => car.HirePrice);

        Console.WriteLine(totalHirePrice);

        if (_contractedCars.Count > 3)
        {
            _discountPercentage = 15;
            totalHirePrice -= (totalHirePrice/100)* _discountPercentage;
            return totalHirePrice;
        }

        _discountPercentage = 10;
        totalHirePrice -= (totalHirePrice / 100) * _discountPercentage;
        return totalHirePrice;
        
    }
}

