namespace AvansDevOps.App.Domain.WorkItemStates;

public class TestingState : IBacklogItemState
{
    public IBacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new TestingState();
    }

    public IBacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new TestingState();
    }

    public IBacklogItemState ToStateReadyForTesting()
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new TestingState();
    }

    public IBacklogItemState ToStateTested()
    {
        return new TestedState();
    }

    public IBacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item is al status testing");
        return new TestingState();
    }

    public IBacklogItemState ToStateToDo()
    {
        return new ToDoState();
    }
}
