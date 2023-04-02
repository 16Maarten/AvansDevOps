using AvansDevOps.App.Domain.GitStates;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Domain.WorkItemStates;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public class BacklogItem : Composite, IWorkItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Person Developer { get; set; }
    public Person Tester { get; set; }
    public int StoryPoints { get; set; }
    public BacklogItemState SprintBoardState { get; set; } = new ToDoState();
    private GitState _gitState = new NoGitState();
    private string _branch = "main";

    public BacklogItem(int id, string title, string description, Person developer, int storyPoints)
    {
        Id = id;
        Title = title;
        Description = description;
        Developer = developer;
        StoryPoints = storyPoints;
    }

    public Thread? CreateThread(string title, string message, Person person)
    {
        if (SprintBoardState.GetType() != typeof(DoneState))
        {
            return new Thread(title, message, person, this, ((Sprint)GetParent()).Developers);
        }

        return null;
    }

    public void ToTodo()
    {
        SprintBoardState = SprintBoardState.ToStateToDo(
            Title,
            ((Sprint)this.GetParent()).ScrumMaster
        );
    }

    public void ToDoing()
    {
        SprintBoardState = SprintBoardState.ToStateDoing();
    }

    public void ToReadyForTesting()
    {
        SprintBoardState = SprintBoardState.ToStateReadyForTesting(Title, Tester);
    }

    public void ToTesting()
    {
        SprintBoardState = SprintBoardState.ToStateTesting();
    }

    public void ToTested()
    {
        SprintBoardState = SprintBoardState.ToStateTested();
    }

    public void ToDone()
    {
        var activities = this.GetChildren().Cast<Activity>().ToList();
        if (activities.Count > 0)
        {
            if (
                this.GetChildren()
                    .Cast<Activity>()
                    .ToList()
                    .TrueForAll(x => x.SprintBoardState.GetType().IsInstanceOfType(new DoneState()))
            )
            {
                SprintBoardState = SprintBoardState.ToStateDone();
            }
            else
            {
                Console.WriteLine("Not all activitites of backlogitem are on state done");
            }
        }
        else
        {
            SprintBoardState = SprintBoardState.ToStateDone();
        }
    }

    public override void AcceptVisitor(Visitor visitor)
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
        _gitState = _gitState.ToStateNoGitByPush(Title, _branch);
    }

    public void GitBranchTo(string branch)
    {
        var stateTuple = _gitState.SwitchBranch(branch);
        _gitState = stateTuple.Item1;
        if (stateTuple.Item2 != null)
            _branch = stateTuple.Item2!;
    }

    public string GetBranch()
    {
        return _branch;
    }
}
