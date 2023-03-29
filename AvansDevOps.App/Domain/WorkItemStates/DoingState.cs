namespace AvansDevOps.App.Domain.WorkItemStates;

public class DoingState : IBacklogItemState
{
    public IBacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item is al status doing");
        return new DoingState();
    }

    public IBacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new DoingState();
    }

    public IBacklogItemState ToStateReadyForTesting()
    {
        return new ReadyForTestingState();
    }

    public IBacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new DoingState();
    }

    public IBacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new DoingState();
    }

    public IBacklogItemState ToStateToDo()
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new DoingState();
    }
}
