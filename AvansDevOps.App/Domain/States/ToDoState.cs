namespace AvansDevOps.App.Domain.States;

public class ToDoState : IBacklogItemState
{
    public IBacklogItemState StateDoing()
    {
        return new DoingState();
    }

    public IBacklogItemState StateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new ToDoState();
    }

    public IBacklogItemState StateReadyForTesting()
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new ToDoState();
    }

    public IBacklogItemState StateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new ToDoState();
    }

    public IBacklogItemState StateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new ToDoState();
    }

    public IBacklogItemState StateToDo()
    {
        Console.WriteLine("Item is al status ToDo");
        return new ToDoState();
    }
}
