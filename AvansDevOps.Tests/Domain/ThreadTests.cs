namespace AvansDevOps.Tests.Domain;

public class ThreadTests
{
    private Thread CreateThread()
    {
        return new Thread("title", "message", new Developer("developer"), new BacklogItem(1, "backlogItem", "description", new Developer("developer"), 20), new List<Developer>());
    }

    [Fact]
    public void Test_AddReply()
    {
        // Arrange
        var thread = CreateThread();
        var reply = new Reply("reply", new Developer("developer"));

        // Act
        thread.AddReply(reply);

        // Assert
        Assert.Contains(reply, thread.Replies);
    }

    [Fact]
    public void Test_RemoveReply()
    {
        // Arrange
        var thread = CreateThread();
        var reply = new Reply("reply", new Developer("developer"));
        thread.AddReply(reply);

        // Act
        thread.RemoveReply(reply);

        // Assert
        Assert.DoesNotContain(reply, thread.Replies);
    }

    //[Fact]
    //public void Test_ToStringWithoutNested()
    //{
    //    // Arrange
    //    var thread = CreateThread();
    //    // Act
    //    var result = thread.ToStringWithoutNested();
    //    // Assert
    //    Assert.Equal("------------\nThread: \"title\"\n------------\n", result);
    //}

    //[Fact]
    //public void Test_ToString()
    //{
    //    // Arrange
    //    var thread = CreateThread();
    //    // Act
    //    var result = thread.ToString();
    //    // Assert
    //    Assert.Equal("------------\nThread: \"title\"\n------------\n", result);
    //}

    [Fact]
    public void Test_AddReply_ItemIsDoneState()
    {
        // Arrange
        var thread = CreateThread();
        var reply = new Reply("reply", new Developer("developer"));
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
        var thread = CreateThread();
        var reply = new Reply("reply", new Developer("developer"));
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
        var thread = CreateThread();

        // Act
        var result = thread.ItemIsNotDoneState();
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ItemIsNotDoneState_ItemIsDoneState()
    {
        // Arrange
        var thread = CreateThread();
        thread.BacklogItem.SprintBoardState = new DoneState();

        // Act
        var result = thread.ItemIsNotDoneState();

        // Assert
        Assert.False(result);
    }
}