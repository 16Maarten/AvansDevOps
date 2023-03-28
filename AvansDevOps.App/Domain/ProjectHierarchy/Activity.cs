using AvansDevOps.App.Domain.States;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public class Activity : IComponent, IWorkItem
{
    private string _title { get; set; }
    private string _description { get; set; }
    private Person _developer { get; set; }
    private Person _tester { get; set; }
    private int _storyPoints { get; set; }
    private IBacklogItemState _state { get; set; }

    public Activity(
        string title,
        string description,
        Person developer,
        Person tester,
        int storyPoints,
        IBacklogItemState state
    )
    {
        _title = title;
        _description = description;
        _developer = developer;
        _tester = tester;
        _storyPoints = storyPoints;
        _state = state;
    }

    public void ToTodo()
    {
        _state = _state.StateToDo();
    }

    public void ToDoing()
    {
        _state = _state.StateDoing();
    }

    public void ToReadyForTesting()
    {
        _state = _state.StateReadyForTesting();
    }

    public void ToTesting()
    {
        _state = _state.StateTesting();
    }

    public void ToTested()
    {
        _state = _state.StateTested();
    }

    public void ToDone()
    {
        // TODO Check of alle activiteiten op done staan
        _state = _state.StateDone();
    }

    public void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitActivity(this);
    }
}
