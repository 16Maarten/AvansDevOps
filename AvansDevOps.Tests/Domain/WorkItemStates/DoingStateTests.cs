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

        var subscriberMock = GlobalUsings.CreateSubscriberMock();

        backlogItem.SprintBoardState.PublisherService.AddObserver(subscriberMock.Object);

        // Act
        backlogItem.ToReadyForTesting();

        // Assert
        using (new AssertionScope())
        {
            Assert.IsType<ReadyForTestingState>(backlogItem.SprintBoardState);
            subscriberMock.Verify(x => x.Update(It.Is<string>(x => x.Contains($"Item {backlogItem.Title} is ready for testing")), It.IsAny<Person[]>()), Times.Once);
        }
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
