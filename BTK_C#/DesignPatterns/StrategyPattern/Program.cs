
CustomerManager customerManager = new CustomerManager();
customerManager.SaveCredit(new PersonalFinanceCreditCalculator());
customerManager.SaveCredit(new CommercialCreditCalculator());


abstract class CreditCalculatorBase
{
    public abstract void Calculate();
}

class PersonalFinanceCreditCalculator : CreditCalculatorBase
{
    public override void Calculate()
    {
        Console.WriteLine("Personal Finance Credit Calculated");
    }
}

class CommercialCreditCalculator : CreditCalculatorBase
{
    public override void Calculate()
    {
        Console.WriteLine("Commercial Credit Calculated");
    }
}

class CustomerManager
{
    public void SaveCredit(CreditCalculatorBase creditCalculator)
    {
        creditCalculator.Calculate();
    }
}