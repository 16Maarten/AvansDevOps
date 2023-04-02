namespace AvansDevOps.Tests.Domain;

public class ThreadTests
{
    [Fact]
    public void Test_AddReply()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        var reply = GlobalUsings.CreateReply();
        var subscriberMock = GlobalUsings.CreateSubscriberMock();

        thread._publisherService.AddObserver(subscriberMock.Object);

        // Act
        thread.AddReply(reply);

        // Assert
        using (new AssertionScope())
        {
            Assert.Contains(reply, thread.Replies);
            subscriberMock.Verify(x => x.Update(It.Is<string>(x => x.Contains($"NEW MESSAGE FOR THREAD {thread._title}\n[{reply.Person.Name}] - {reply.Message}")), It.IsAny<Person[]>()), Times.Once);
        }
    }

    [Fact]
    public void Test_RemoveReply()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        var reply = GlobalUsings.CreateReply();
        thread.AddReply(reply);

        // Act
        thread.RemoveReply(reply);

        // Assert
        Assert.DoesNotContain(reply, thread.Replies);
    }

    [Fact]
    public void Test_ToStringWithoutNested()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        // Act
        var result = thread.ToStringWithoutNested();
        // Assert
        using (new AssertionScope())
        {
            Assert.Contains($"------------\nThread: \"{thread._title}\"\n------------\n", result);
            Assert.Contains($"message", result);
            Assert.Contains($"developer", result);
        }
    }

    [Fact]
    public void Test_ToString()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        // Act
        var result = thread.ToString();
        // Assert
        using (new AssertionScope())
        {
            Assert.Contains($"------------\nThread: \"{thread._title}\"\n------------\n", result);
            Assert.Contains($"message", result);
            Assert.Contains($"developer", result);
        }
    }

    [Fact]
    public void Test_AddReply_ItemIsDoneState()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        var reply = GlobalUsings.CreateReply();
        thread.BacklogItem.SprintBoardState = new DoneState();

        // Act
        thread.AddReply(reply);

        // Assert
        Assert.DoesNotContain(reply, thread.Replies);
    }

    [Fact]
    public void Test_RemoveReply_ItemIsDoneState()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        var reply = GlobalUsings.CreateReply();
        thread.AddReply(reply);
        thread.BacklogItem.SprintBoardState = new DoneState();

        // Act
        thread.RemoveReply(reply);

        // Assert
        Assert.Contains(reply, thread.Replies);
    }

    [Fact]
    public void Test_ItemIsNotDoneState()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();

        // Act
        var result = thread.ItemIsNotDoneState();
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ItemIsNotDoneState_ItemIsDoneState()
    {
        // Arrange
        var thread = GlobalUsings.CreateThread();
        thread.BacklogItem.SprintBoardState = new DoneState();

        // Act
        var result = thread.ItemIsNotDoneState();

        // Assert
        Assert.False(result);
    }
}