using AvansDevOps.App.Domain.ProjectHierarchy;

namespace AvansDevOps.Tests.Domain;

public class ToDoStateTests
{
    [Fact]
    public void Test_ToToDotState()
    {
        // Arrange
        var backlogItem = GlobalUsings.CreateBacklogItem();
        // Act
        backlogItem.ToTodo();
        // Assert
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoingtState()
    {
        // Arrange
        var backlogItem = GlobalUsings.CreateBacklogItem();
        // Act
        backlogItem.ToDoing();
        // Assert
        Assert.IsType<DoingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToReadyForTestingState()
    {
        // Arrange
        var backlogItem = GlobalUsings.CreateBacklogItem();
        // Act
        backlogItem.ToReadyForTesting();
        // Assert
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestingState()
    {
        // Arrange
        var backlogItem = GlobalUsings.CreateBacklogItem();
        // Act
        backlogItem.ToTesting();
        // Assert
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestedState()
    {
        // Arrange
        var backlogItem = GlobalUsings.CreateBacklogItem();
        // Act
        backlogItem.ToTested();
        // Assert
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoneState()
    {
        // Arrange
        var backlogItem = GlobalUsings.CreateBacklogItem();
        // Act
        backlogItem.ToDone();
        // Assert
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }
}
