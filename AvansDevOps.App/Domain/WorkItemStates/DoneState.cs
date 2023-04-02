using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain.WorkItemStates;

public class DoneState : BacklogItemState
{
    public override BacklogItemState ToStateToDo(string itemTitle, Person scrumMaster)
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new DoneState();
    }

    public override BacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new DoneState();
    }

    public override BacklogItemState ToStateReadyForTesting(string itemTitle, Person tester)
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new DoneState();
    }

    public override BacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new DoneState();
    }

    public override BacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new DoneState();
    }

    public override BacklogItemState ToStateDone()
    {
        Console.WriteLine("Item is al status done");
        return new DoneState();
    }
}
