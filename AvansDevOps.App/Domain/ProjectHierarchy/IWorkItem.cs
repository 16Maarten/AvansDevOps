namespace AvansDevOps.App.Domain.ProjectHierarchy;

public interface IWorkItem
{
    public void ToTodo();
    public void ToDoing();
    public void ToReadyForTesting();
    public void ToTesting();
    public void ToTested();
    public void ToDone();

    public void GitRemove();
    public void GitAdd(string codeSnippet);
    public void GitCommit(string commitMessage);
    public void GitPush();
    public void GitBranchTo(string branch);
    public string GetBranch();
}
