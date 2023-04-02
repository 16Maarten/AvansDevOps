using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain.WorkItemStates;

public class TestedState : BacklogItemState
{
    public override BacklogItemState ToStateToDo(string itemTitle, Person scrumMaster)
    {
        return new ToDoState();
    }

    public override BacklogItemState ToStateDoing()
    {
        Console.WriteLine("Item kan niet naar status doing");
        return new TestedState();
    }

    public override BacklogItemState ToStateReadyForTesting(string itemTitle, Person tester)
    {
        return new ReadyForTestingState();
    }

    public override BacklogItemState ToStateTesting()
    {
        Console.WriteLine("Item kan niet naar status testing");
        return new TestedState();
    }

    public override BacklogItemState ToStateTested()
    {
        Console.WriteLine("Item is al status tested");
        return new TestedState();
    }

    public override BacklogItemState ToStateDone()
    {
        return new DoneState();
    }
}
