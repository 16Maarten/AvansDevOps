namespace AvansDevOps.Tests.Domain.GitStates;

public class GitStateTests
{
    [Fact]
    public void Test_PushChanges()
    {
        // Arrange
        var state = new CommittedState(GlobalUsings.CreateCommits());

        // Act
        var result = state.PushChanges("workitem", "main");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_GetAddedChanges()
    {
        // Arrange
        var state = new AddedState(GlobalUsings.CreateChanges(), GlobalUsings.CreateCommits());

        // Act
        var result = state.GetAddedChanges();

        // Assert
        using (new AssertionScope())
        {
            Assert.Contains("-> code1", result);
            Assert.Contains("-> code2", result);
            Assert.Contains("-> code3", result);
            Assert.Contains("-> code4", result);
            Assert.Contains("-> code5", result);
            Assert.Contains("-> code6", result);
        }
    }

    [Fact]
    public void Test_GetCommittedChanges()
    {
        // Arrange
        var state = new AddedState(GlobalUsings.CreateChanges(), GlobalUsings.CreateCommits());

        // Act
        var result = state.GetCommittedChanges();

        // Assert
        Assert.Contains("Commit: commit1\r\n-> code1\r\n-> code2\r\n", result);
    }

}
