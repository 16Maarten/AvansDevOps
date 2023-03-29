namespace AvansDevOps.App.Domain.WorkItemStates;

public class TestedState : IBacklogItemState
{
    public IBacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new TestedState();
    }

    public IBacklogItemState ToStateDone()
    {
        return new DoneState();
    }

    public IBacklogItemState ToStateReadyForTesting()
    {
        return new ReadyForTestingState();
    }

    public IBacklogItemState ToStateTested()
    {
        Console.WriteLine("Item is al status tested");
        return new TestedState();
    }

    public IBacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new TestedState();
    }

    public IBacklogItemState ToStateToDo()
    {
        return new ToDoState();
    }
}
