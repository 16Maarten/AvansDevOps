using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain.WorkItemStates;

public class TestingState : BacklogItemState
{
    public override BacklogItemState ToStateToDo(string itemTile, Person scrumMaster)
    {
        PublisherService.NotifyObservers($"Item {itemTile} is moved from 'testing' to 'to do'", scrumMaster);
        return new ToDoState();
    }

    public override BacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new TestingState();
    }

    public override BacklogItemState ToStateReadyForTesting(string itemTile, Person tester)
    {
        Console.WriteLine("Item kan niet naar status ready for testing");
        return new TestingState();
    }

    public override BacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item is al status testing");
        return new TestingState();
    }

    public override BacklogItemState ToStateTested()
    {
        return new TestedState();
    }

    public override BacklogItemState ToStateDone()
    {
        Console.WriteLine("Item kan niet naar status done");
        return new TestingState();
    }
}
