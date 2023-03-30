using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain.WorkItemStates;

public class ToDoState : BacklogItemState
{
    public override BacklogItemState ToStateToDo(string itemTile, Person scrumMaster)
    {
        Console.WriteLine("Item is al status ToDo");
        return new ToDoState();
    }

    public override BacklogItemState ToStateDoing()
    {
        return new DoingState();
    }

    public override BacklogItemState ToStateReadyForTesting(string itemTile, Person tester)
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new ToDoState();
    }

    public override BacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new ToDoState();
    }

    public override BacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new ToDoState();
    }

    public override BacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new ToDoState();
    }
}
