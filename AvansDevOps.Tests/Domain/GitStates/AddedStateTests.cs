namespace AvansDevOps.Tests.Domain.GitStates;

public class AddedStateTests
{
    [Fact]
    public void Test_ToStateNoGit()
    {
        // Arrange
        var state = new AddedState(new List<string>());

        // Act
        var result = state.ToStateNoGit();

        // Assert
        Assert.IsType<NoGitState>(result);
    }

    [Fact]
    public void Test_ToStateAdded()
    {
        // Arrange
        var state = new AddedState(GlobalUsings.CreateChanges());

        // Act
        var result = state.ToStateAdded("codesnippet");

        // Assert
        using (new AssertionScope())
        {
            Assert.IsType<AddedState>(result);
            result.AddedChanges.Contains("codesnippet");
        }
    }

    [Fact]
    public void Test_ToStateCommitted()
    {
        // Arrange
        var state = new AddedState(GlobalUsings.CreateChanges());

        // Act
        var result = state.ToStateCommitted("commitmessage");

        // Assert
        Assert.IsType<CommittedState>(result);
    }

    [Fact]
    public void Test_ToStateNoGitByPush()
    {
        // Arrange
        var state = new AddedState(GlobalUsings.CreateChanges());

        // Act
        var result = state.ToStateNoGitByPush("workitemtitle", "branch");

        // Assert
        Assert.IsType<AddedState>(result);
    }

    [Fact]
    public void Test_SwitchBranch()
    {
        // Arrange
        var state = new AddedState(GlobalUsings.CreateChanges());

        // Act
        var result = state.SwitchBranch("branch");

        // Assert
        using (new AssertionScope())
        {
            Assert.IsType<AddedState>(result.Item1);
            Assert.Null(result.Item2);
        }
    }
}