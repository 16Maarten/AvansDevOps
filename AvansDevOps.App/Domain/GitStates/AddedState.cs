namespace AvansDevOps.App.Domain.GitStates;

public class AddedState : GitState
{
    public AddedState(List<string> addedCodeSnippets) : base(addedCodeSnippets) { }
    public AddedState(List<string> addedCodeSnippets, Dictionary<string, List<string>> addedCommits) : base(addedCodeSnippets, addedCommits) { }

    public override GitState ToStateNoGit()
    {
        Console.WriteLine($"Added changes{(base._addedCommits.Count == 0 ? " " : " and commits ")}are removed.");
        return new NoGitState();
    }

    public override GitState ToStateAdded(string codeSnippet)
    {
        base._addedChanges.Add(codeSnippet);
        Console.WriteLine("Change is added.");
        Console.WriteLine($"Changes:\n{GetAddedChanges()}");
        return this;
    }

    public override GitState ToStateCommitted(string commitMessage)
    {
        base._addedCommits.Add(commitMessage, base._addedChanges);
        Console.WriteLine($"Changes are committed with message {commitMessage}");
        return new CommittedState(base._addedCommits);
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
