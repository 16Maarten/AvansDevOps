using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain.WorkItemStates;

public class ReadyForTestingState : BacklogItemState
{
    public override BacklogItemState ToStateToDo(string itemTile, Person scrumMaster)
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new ReadyForTestingState();
    }

    public override BacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new ReadyForTestingState();
    }

    public override BacklogItemState ToStateReadyForTesting(string itemTile, Person tester)
    {
        Console.WriteLine("Item is al status ready for testing");
        return new ReadyForTestingState();
    }

    public override BacklogItemState ToStateTesting()
    {
        return new TestingState();
    }

    public override BacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new ReadyForTestingState();
    }

    public override BacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new ReadyForTestingState();
    }
}
