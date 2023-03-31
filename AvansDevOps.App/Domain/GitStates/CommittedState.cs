namespace AvansDevOps.App.Domain.GitStates;

public class CommittedState : GitState
{
    public CommittedState(Dictionary<string, List<string>> addedCommits) : base(addedCommits) { }

    public override GitState ToStateNoGit()
    {
        Console.WriteLine("Added changes and commits are removed.");
        return new NoGitState();
    }

    public override GitState ToStateAdded(string codeSnippet)
    {
        Console.WriteLine("Change is added.");
        Console.WriteLine($"Changes:\n{GetAddedChanges()}");
        return new AddedState(new List<string>() { codeSnippet }, base.AddedCommits);
    }

    public override GitState ToStateCommitted(string commitMessage)
    {
        Console.WriteLine($"Changes are already committed.");
        Console.WriteLine($"Commits:\n{GetCommittedChanges()}");
        return this;
    }

    public override GitState ToStateNoGitByPush(string workItemTitle, string branch)
    {
        PushChanges(workItemTitle, branch);
        return new NoGitState();
    }

    public override (GitState, string?) SwitchBranch(string branch)
    {
        Console.WriteLine($"Switched to branch: '{branch}'.");
        return (new NoGitState(base.AddedCommits), branch);
    }
}
