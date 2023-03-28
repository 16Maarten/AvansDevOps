namespace AvansDevOps.App.Domain.States;

public class DoneState : IBacklogItemState
{
    public IBacklogItemState StateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new DoneState();
    }

    public IBacklogItemState StateDone()
    {
        Console.WriteLine("Item is al status done");
        return new DoneState();
    }

    public IBacklogItemState StateReadyForTesting()
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new DoneState();
    }

    public IBacklogItemState StateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new DoneState();
    }

    public IBacklogItemState StateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new DoneState();
    }

    public IBacklogItemState StateToDo()
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new DoneState();
    }
}
