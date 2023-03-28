namespace AvansDevOps.App.Domain.States;

public class DoingState : IBacklogItemState
{
    public IBacklogItemState StateDoing()
    {
        Console.WriteLine("Item is al status doing");
        return new DoingState();
    }

    public IBacklogItemState StateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new DoingState();
    }

    public IBacklogItemState StateReadyForTesting()
    {
        return new ReadyForTestingState();
    }

    public IBacklogItemState StateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new DoingState();
    }

    public IBacklogItemState StateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new DoingState();
    }

    public IBacklogItemState StateToDo()
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new DoingState();
    }
}
