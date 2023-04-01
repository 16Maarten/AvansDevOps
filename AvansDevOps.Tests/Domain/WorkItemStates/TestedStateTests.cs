using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace AvansDevOps.Tests.Domain;

public class TestedStateTests
{
    private BacklogItem CreateBacklogItem()
    {
        var sprint = new ReleaseSprint(
            1,
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            new ScrumMaster("ScrumMaster"),
            new List<Developer>()
        );
        var developer = new Developer("developer");
        var backlogItem = new BacklogItem(1, "story", "story 1", developer, 5);
        backlogItem.Tester = developer;
        backlogItem.SetParent(sprint);
        backlogItem.ToDoing();
        backlogItem.ToReadyForTesting();
        backlogItem.ToTesting();
        backlogItem.ToTested();
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
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoingtState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToDoing();
        // Assert
        Assert.IsType<TestedState>(backlogItem.SprintBoardState);
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
        Assert.IsType<TestedState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestedState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToTested();
        // Assert
        Assert.IsType<TestedState>(backlogItem.SprintBoardState);
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
