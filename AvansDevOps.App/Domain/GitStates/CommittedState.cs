﻿using AvansDevOps.App.Domain.WorkItemStates;

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
        return new AddedState(new List<string>() { codeSnippet }, base._addedCommits);
    }

    public override GitState ToStateCommitted(string commitMessage)
    {
        Console.WriteLine($"Changes are already committed."); 
        Console.WriteLine($"Commits:\n{GetCommittedChanges()}");
        return this;
    }

    public override GitState ToStateNoGitByPush(string workItem, string branch)
    {
        PushChanges(workItem, branch);
        return new NoGitState();
    }

    public override (GitState, string?) SwitchBranch(string branch)
    {
        Console.WriteLine($"Switched to branch: '{branch}'.");
        return (new NoGitState(base._addedCommits), branch);
    }
}