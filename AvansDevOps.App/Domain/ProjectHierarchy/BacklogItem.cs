using AvansDevOps.App.Domain.WorkItemStates;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;
using AvansDevOps.App.Domain.GitStates;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public class BacklogItem : Composite, IWorkItem
{
    private string _title { get; set; }
    private string _description { get; set; }
    private Person _developer { get; set; }
    private Person _tester { get; set; }
    private int _storyPoints { get; set; }
    private IBacklogItemState _sprintBoardState { get; set; }
    private GitState _gitState = new NoGitState();
    private string _branch = "main";

    public BacklogItem(
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
        _sprintBoardState = state;
    }

    public void ToTodo()
    {
        _sprintBoardState = _sprintBoardState.ToStateToDo();
    }

    public void ToDoing()
    {
        _sprintBoardState = _sprintBoardState.ToStateDoing();
    }

    public void ToReadyForTesting()
    {
        _sprintBoardState = _sprintBoardState.ToStateReadyForTesting();
    }

    public void ToTesting()
    {
        _sprintBoardState = _sprintBoardState.ToStateTesting();
    }

    public void ToTested()
    {
        _sprintBoardState = _sprintBoardState.ToStateTested();
    }

    public void ToDone()
    {
        // TODO Check of alle activiteiten op done staan
        _sprintBoardState = _sprintBoardState.ToStateDone();
    }

    public void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitBacklogItem(this);
        base.AcceptVisitor(visitor);
    }

    public void GitRemove()
    {
        _gitState = _gitState.ToStateNoGit();
    }

    public void GitAdd(string codeSnippet)
    {
        _gitState = _gitState.ToStateAdded(codeSnippet);
    }

    public void GitCommit(string commitMessage)
    {
        _gitState = _gitState.ToStateCommitted(commitMessage);
    }

    public void GitPush()
    {
        _gitState = _gitState.ToStateNoGitByPush(_title, _branch);
    }

    public void GitBranchTo(string branch)
    {
        var stateTuple = _gitState.SwitchBranch(branch);
        _gitState = stateTuple.Item1;
        if (stateTuple.Item2 != null) _branch = stateTuple.Item2!;
    }

    public string GetBranch()
    {
        return _branch;
    }
}
