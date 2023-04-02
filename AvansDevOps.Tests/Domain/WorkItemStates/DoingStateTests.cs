namespace AvansDevOps.Tests.Domain;

public class DoingStateTests
{
    private BacklogItem CreateBacklogItem()
    {
        var backlogItem = GlobalUsings.CreateBacklogItem();
        backlogItem.ToDoing();
        return backlogItem;
    }

    [Fact]
    public void Test_ToToDotState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToTodo();
        // Assert
        Assert.IsType<DoingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoingtState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToDoing();
        // Assert
        Assert.IsType<DoingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToReadyForTestingState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToReadyForTesting();
        // Assert
        Assert.IsType<ReadyForTestingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestingState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToTesting();
        // Assert
        Assert.IsType<DoingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestedState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToTested();
        // Assert
        Assert.IsType<DoingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoneState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToDone();
        // Assert
        Assert.IsType<DoingState>(backlogItem.SprintBoardState);
    }
}
