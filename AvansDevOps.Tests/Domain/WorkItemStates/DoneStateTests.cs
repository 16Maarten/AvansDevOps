namespace AvansDevOps.Tests.Domain;

public class DoneStateTests
{
    private BacklogItem CreateBacklogItem()
    {
        var backlogItem = GlobalUsings.CreateBacklogItem();
        backlogItem.ToDoing();
        backlogItem.ToReadyForTesting();
        backlogItem.ToTesting();
        backlogItem.ToTested();
        backlogItem.ToDone();
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
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoingtState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToDoing();

        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToReadyForTestingState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToReadyForTesting();

        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestingState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToTesting();

        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestedState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToTested();

        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoneState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToDone();

        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }
}
