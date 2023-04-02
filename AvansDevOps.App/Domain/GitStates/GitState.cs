using System.Text;

namespace AvansDevOps.App.Domain.GitStates;

public abstract class GitState
{
    public List<string> AddedChanges = new List<string>();
    public Dictionary<string, List<string>> AddedCommits = new Dictionary<string, List<string>>();

    public GitState() { }

    public GitState(List<string> addedCodeSnippets)
    {
        AddedChanges = addedCodeSnippets;
    }

    public GitState(Dictionary<string, List<string>> addedCommits)
    {
        AddedCommits = addedCommits;
    }
    public GitState(List<string> addedCodeSnippets, Dictionary<string, List<string>> addedCommits)
    {
        AddedChanges = addedCodeSnippets;
        AddedCommits = addedCommits;
    }

    public abstract GitState ToStateNoGit();
    public abstract GitState ToStateAdded(string codeSnippet);
    public abstract GitState ToStateCommitted(string commitMessage);
    public abstract GitState ToStateNoGitByPush(string workItemTitle, string branch);
    public abstract (GitState, string?) SwitchBranch(string branch);

    public virtual bool PushChanges(string workItem, string branch)
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var committedChanges in AddedCommits)
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

            File.WriteAllText($"../../../Exports/{workItem}.txt", stringBuilder.ToString());

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public string GetAddedChanges()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("--------------------------------------------");
        foreach (var addedChanges in AddedChanges)
        {
            stringBuilder.AppendLine($"-> {addedChanges}");
        }
        stringBuilder.AppendLine("--------------------------------------------");

        return stringBuilder.ToString();
    }

    public string GetCommittedChanges()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var committedChanges in AddedCommits)
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
