namespace AvansDevOps.App.Domain.GitStates;

public class NoGitState : GitState
{
    public NoGitState() { }
    public NoGitState(Dictionary<string, List<string>> addedCommits) : base(addedCommits) { }
    public override GitState ToStateNoGit()
    {
        Console.WriteLine("Changes are already not added, committed or pushed.");
        return new NoGitState();
    }

    public override GitState ToStateAdded(string codeSnippet)
    {
        base._addedChanges.Add(codeSnippet);
        Console.WriteLine("Change is added.");
        Console.WriteLine($"Changes:\n{GetAddedChanges()}");
        return new AddedState(base._addedChanges);
    }

    public override GitState ToStateCommitted(string commitMessage)
    {
        Console.WriteLine("Change cannot be committed. Please add first.");
        return new NoGitState();
    }

    public override GitState ToStateNoGitByPush(string workItemTitle, string branch)
    {
        if (base._addedCommits.Count() > 0)
        {
            PushChanges(workItemTitle, branch);
        }

        Console.WriteLine("Change cannot be pushed. Please add and commit first.");
        return new NoGitState();
    }

    public override (GitState, string?) SwitchBranch(string branch)
    {
        Console.WriteLine($"Switched to branch: '{branch}'.");
        return (new NoGitState(), branch);
    }
}
