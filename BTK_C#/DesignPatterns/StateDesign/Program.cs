

Context context = new Context();
context.SetState(new ModifiedState());
context.GetState().DoAction(context);

DeletedState deletedState = new DeletedState();
context.SetState(deletedState);
deletedState.DoAction(context);

interface IState
{
    void DoAction(Context context);

}

class ModifiedState :IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State is Modified");
    }
}

class DeletedState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State is Deleted");
    }
}

class AddedState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State is Added");
    }
}

internal class Context
{
    IState state;
    public void SetState(IState state)
    {
        this.state = state;
    }

    public IState GetState()
    {
        return state;
    }

}



