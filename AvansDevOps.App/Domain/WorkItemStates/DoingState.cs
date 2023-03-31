using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain.WorkItemStates;

public class DoingState : BacklogItemState
{
    public override BacklogItemState ToStateToDo(string itemTile, Person scrumMaster)
    {
        Console.WriteLine("Item kan niet naar status todo");
        return new DoingState();
    }

    public override BacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item is al status doing");
        return new DoingState();
    }

    public override BacklogItemState ToStateReadyForTesting(string itemTile, Person tester)
    {
        PublisherService.NotifyObservers($"Item {itemTile} is ready for testing", tester);
        return new ReadyForTestingState();
    }

    public override BacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new DoingState();
    }

    public override BacklogItemState ToStateTested()
    {
        Console.WriteLine("Item kan niet naar status tested");
        return new DoingState();
    }

    public override BacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new DoingState();
    }
}
