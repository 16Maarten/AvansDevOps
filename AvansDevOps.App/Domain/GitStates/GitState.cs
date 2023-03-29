using AvansDevOps.App.Domain.ProjectHierarchy;
using System.Text;

namespace AvansDevOps.App.Domain.GitStates;

public abstract class GitState
{
    public List<string> _addedChanges = new List<string>();
    public Dictionary<string, List<string>> _addedCommits = new Dictionary<string, List<string>>();

    public GitState() { }

    public GitState(List<string> addedCodeSnippets)
    {
        _addedChanges = addedCodeSnippets;
    }

    public GitState(Dictionary<string, List<string>> addedCommits)
    {
        _addedCommits = addedCommits;
    }
    public GitState(List<string> addedCodeSnippets, Dictionary<string, List<string>> addedCommits)
    {
        _addedChanges = addedCodeSnippets;
        _addedCommits = addedCommits;
    }

    public abstract GitState ToStateNoGit();
    public abstract GitState ToStateAdded(string codeSnippet);
    public abstract GitState ToStateCommitted(string commitMessage);
    public abstract GitState ToStateNoGitByPush(string workItemTitle, string branch);
    public abstract (GitState, string?) SwitchBranch(string branch);

    public void PushChanges(string workItem, string branch)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var committedChanges in _addedCommits)
        {
            stringBuilder.AppendLine("--------------------------------------------");
            stringBuilder.AppendLine($"Branch: {branch}");
            stringBuilder.AppendLine($"Commit: {committedChanges.Key}");
            foreach (var addedChanges in committedChanges.Value)
            {
                stringBuilder.AppendLine($"-> {addedChanges}");
            }
            stringBuilder.AppendLine("--------------------------------------------");
        }

        File.WriteAllText($"../../../../Exports/{workItem}.text", stringBuilder.ToString());
    }

    public string GetAddedChanges()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("--------------------------------------------");
        foreach (var addedChanges in _addedChanges)
        {
            stringBuilder.AppendLine($"-> {addedChanges}");
        }
        stringBuilder.AppendLine("--------------------------------------------");

        return stringBuilder.ToString();
    }
    public string GetCommittedChanges()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var committedChanges in _addedCommits)
        {
            stringBuilder.AppendLine("--------------------------------------------");
            stringBuilder.AppendLine($"Commit: {committedChanges.Key}");
            foreach (var addedChanges in committedChanges.Value)
            {
                stringBuilder.AppendLine($"-> {addedChanges}");
            }
            stringBuilder.AppendLine("--------------------------------------------");
        }

        return stringBuilder.ToString();
    }
}
