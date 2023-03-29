namespace AvansDevOps.App.Domain.WorkItemStates;

public class ReadyForTestingState : IBacklogItemState
{
    public IBacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new ReadyForTestingState();
    }

    public IBacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new ReadyForTestingState();
    }

    public IBacklogItemState ToStateReadyForTesting()
    {
        Console.WriteLine("Item is al status ready for testing");
        return new ReadyForTestingState();
    }

    public IBacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new ReadyForTestingState();
    }

    public IBacklogItemState ToStateTesting()
    {
        return new TestingState();
    }

    public IBacklogItemState ToStateToDo()
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new ReadyForTestingState();
    }
}
