namespace AvansDevOps.App.Domain.WorkItemStates;

public class ToDoState : IBacklogItemState
{
    public IBacklogItemState ToStateDoing()
    {
        return new DoingState();
    }

    public IBacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new ToDoState();
    }

    public IBacklogItemState ToStateReadyForTesting()
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new ToDoState();
    }

    public IBacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new ToDoState();
    }

    public IBacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new ToDoState();
    }

    public IBacklogItemState ToStateToDo()
    {
        Console.WriteLine("Item is al status ToDo");
        return new ToDoState();
    }
}
