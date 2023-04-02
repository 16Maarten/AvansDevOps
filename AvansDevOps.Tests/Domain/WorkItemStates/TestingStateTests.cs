namespace AvansDevOps.Tests.Domain;

public class TestingSateStateTests
{
    private BacklogItem CreateBacklogItem()
    {
        var backlogItem = GlobalUsings.CreateBacklogItem();
        backlogItem.ToDoing();
        backlogItem.ToReadyForTesting();
        backlogItem.ToTesting();
        return backlogItem;
    }

    [Fact]
    public void Test_ToToDotState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();
        var subscriberMock = GlobalUsings.CreateSubscriberMock();

        backlogItem.SprintBoardState.PublisherService.AddObserver(subscriberMock.Object);

        // Act
        backlogItem.ToTodo();

        // Assert
        using (new AssertionScope())
        {
            Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
            subscriberMock.Verify(x => x.Update(It.Is<string>(x => x.Contains($"Item {backlogItem.Title} is moved from 'testing' to 'to do'")), It.IsAny<Person[]>()), Times.Once);
        }
    }

    [Fact]
    public void Test_ToDoingtState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToDoing();

        // Assert
        Assert.IsType<TestingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToReadyForTestingState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToReadyForTesting();

        // Assert
        Assert.IsType<TestingState>(backlogItem.SprintBoardState);
    }

    [Fact]
    public void Test_ToTestingState()
    {
        // Arrange
        var backlogItem = CreateBacklogItem();

        // Act
        backlogItem.ToTesting();

        // Assert
        Assert.IsType<TestingState>(backlogItem.SprintBoardState);
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
        Assert.IsType<TestingState>(backlogItem.SprintBoardState);
    }
}
