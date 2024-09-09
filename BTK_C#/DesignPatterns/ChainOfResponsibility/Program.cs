

Manager manager = new Manager();
VicePresident vicePresident = new VicePresident();
Ceo ceo = new Ceo();

manager.SetSuccessor(vicePresident);
vicePresident.SetSuccessor(ceo);

Expense trainingExpense = new Expense { Detail = "Training", Amount = 1200 };
manager.HandleExpense(trainingExpense);


class Expense
{
    public string Detail { get; set; }
    public decimal Amount { get; set; }
}

abstract class ExpenseHandlerBase
{
    protected ExpenseHandlerBase Successor;
    public abstract void HandleExpense(Expense expense);

    public void SetSuccessor(ExpenseHandlerBase successor)
    {
        Successor = successor;
    }
}

class Manager : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount <= 100)
        {
            Console.WriteLine("Manager handled the expense!");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }
    }
}

class VicePresident : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 100 && expense.Amount <= 1000)
        {
            Console.WriteLine("Vice President handled the expense!");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }
    }
}

class Ceo : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 1000)
        {
            Console.WriteLine("Ceo handled the expense!");
        }
    }
}

