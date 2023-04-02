namespace AvansDevOps.Tests.Domain.GitStates;

public class CommittedStateTests
{
    [Fact]
    public void Test_ToStateNoGit()
    {
        // Arrange
        var state = new CommittedState(new Dictionary<string, List<string>>());

        // Act
        var result = state.ToStateNoGit();

        // Assert
        Assert.IsType<NoGitState>(result);
    }

    [Fact]
    public void Test_ToStateAdded()
    {
        // Arrange
        var state = new CommittedState(GlobalUsings.CreateCommits());

        // Act
        var result = state.ToStateAdded("codesnippet");

        // Assert
        using (new AssertionScope())
        {
            Assert.IsType<AddedState>(result);
            result.AddedChanges.Contains("codesnippet");
            result.AddedCommits["commit1"].Contains("code1");
        }
    }

    [Fact]
    public void Test_ToStateCommitted()
    {
        // Arrange
        var state = new CommittedState(GlobalUsings.CreateCommits());

        // Act
        var result = state.ToStateCommitted("commitmessage");

        // Assert
        Assert.Equal(state, result);
    }

    [Fact]
    public void Test_ToStateNoGitByPush()
    {
        // Arrange
        var state = new CommittedState(GlobalUsings.CreateCommits());

        // Act
        var result = state.ToStateNoGitByPush("workitemtitle", "branch");

        // Assert
        Assert.IsType<NoGitState>(result);
    }

    [Fact]
    public void Test_SwitchBranch()
    {
        // Arrange
        var state = new CommittedState(GlobalUsings.CreateCommits());

        // Act
        var result = state.SwitchBranch("branch");

        // Assert
        using (new AssertionScope())
        {
            Assert.IsType<NoGitState>(result.Item1);
            Assert.IsType<string>(result.Item2);
            result.Item1.AddedCommits["commit1"].Contains("code1");
        }
    }
}