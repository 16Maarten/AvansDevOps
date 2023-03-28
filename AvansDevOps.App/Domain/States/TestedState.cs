namespace AvansDevOps.App.Domain.States;

public class TestedState : IBacklogItemState
{
    public IBacklogItemState StateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new TestedState();
    }

    public IBacklogItemState StateDone()
    {
        return new DoneState();
    }

    public IBacklogItemState StateReadyForTesting()
    {
        return new ReadyForTestingState();
    }

    public IBacklogItemState StateTested()
    {
        Console.WriteLine("Item is al status tested");
        return new TestedState();
    }

    public IBacklogItemState StateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new TestedState();
    }

    public IBacklogItemState StateToDo()
    {
        return new ToDoState();
    }
}
