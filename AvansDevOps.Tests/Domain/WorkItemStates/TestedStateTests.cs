namespace AvansDevOps.Tests.Domain;

public class TestedStateTests
{
    private BacklogItem CreateBacklogItem()
    {
        var backlogItem = GlobalUsings.CreateBacklogItem();
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
    public void Test_ToDoneState1()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        // Act
        backlogItem.ToDone();
        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoneState2()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        var developer = new Developer("Dev", "dev@gmail.com", "id12");
        backlogItem.AddComponent(
            new Activity(1, "Inlog pagina", "Maak een inlog pagina", developer, 2)
        );
        // Act
        backlogItem.ToDone();
        // Assert
        Assert.IsType<TestedState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToDoneState3()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        var developer = new Developer("Dev", "dev@gmail.com", "id12");
        var activity = new Activity(1, "Inlog pagina", "Maak een inlog pagina", developer, 2);
        activity.SprintBoardState = new DoneState();
        backlogItem.AddComponent(activity);
        // Act
        backlogItem.ToDone();
        // Assert
        Assert.IsType<DoneState>(backlogItem.SprintBoardState);
    }
}
