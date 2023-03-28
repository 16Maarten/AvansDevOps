namespace AvansDevOps.App.Domain.States;

public class ReadyForTestingState : IBacklogItemState
{
    public IBacklogItemState StateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new ReadyForTestingState();
    }

    public IBacklogItemState StateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new ReadyForTestingState();
    }

    public IBacklogItemState StateReadyForTesting()
    {
        Console.WriteLine("Item is al status ready for testing");
        return new ReadyForTestingState();
    }

    public IBacklogItemState StateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new ReadyForTestingState();
    }

    public IBacklogItemState StateTesting()
    {
        return new TestingState();
    }

    public IBacklogItemState StateToDo()
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new ReadyForTestingState();
    }
}
