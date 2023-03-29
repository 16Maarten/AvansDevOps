namespace AvansDevOps.App.Domain.WorkItemStates;

public class DoneState : IBacklogItemState
{
    public IBacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new DoneState();
    }

    public IBacklogItemState ToStateDone()
    {
        Console.WriteLine("Item is al status done");
        return new DoneState();
    }

    public IBacklogItemState ToStateReadyForTesting()
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new DoneState();
    }

    public IBacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new DoneState();
    }

    public IBacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new DoneState();
    }

    public IBacklogItemState ToStateToDo()
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new DoneState();
    }
}
