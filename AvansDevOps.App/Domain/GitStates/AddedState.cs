namespace AvansDevOps.App.Domain.GitStates;

public class AddedState : GitState
{
    public AddedState(List<string> addedCodeSnippets) : base(addedCodeSnippets) { }
    public AddedState(List<string> addedCodeSnippets, Dictionary<string, List<string>> addedCommits) : base(addedCodeSnippets, addedCommits) { }

    public override GitState ToStateNoGit()
    {
        Console.WriteLine($"Added changes{(base.AddedCommits.Count == 0 ? " " : " and commits ")}are removed.");
        return new NoGitState();
    }

    public override GitState ToStateAdded(string codeSnippet)
    {
        base.AddedChanges.Add(codeSnippet);
        Console.WriteLine("Change is added.");
        Console.WriteLine($"Changes:\n{GetAddedChanges()}");
        return this;
    }

    public override GitState ToStateCommitted(string commitMessage)
    {
        base.AddedCommits.Add(commitMessage, base.AddedChanges);
        Console.WriteLine($"Changes are committed with message {commitMessage}");
        return new CommittedState(base.AddedCommits);
    }

    public override GitState ToStateNoGitByPush(string workItemTitle, string branch)
    {
        Console.WriteLine("Change cannot be pushed. Please commit last added change first.");
        return this;
    }

    public override (GitState, string?) SwitchBranch(string branch)
    {
        Console.WriteLine("Cannot change branch. Please commit changes first.");
        return (this, null);
    }
}
