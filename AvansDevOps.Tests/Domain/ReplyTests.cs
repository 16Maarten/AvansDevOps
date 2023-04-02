namespace AvansDevOps.Tests.Domain;

public class ReplyTests
{
    [Fact]
    public void Test_AddReply()
    {
        // Arrange
        var reply1 = GlobalUsings.CreateReply();
        var reply2 = GlobalUsings.CreateReply();

        // Act
        reply1.AddReply(reply2);

        // Assert
        Assert.Contains(reply2, reply1.Replies);
    }

    [Fact]
    public void Test_RemoveReply()
    {
        // Arrange
        var reply1 = GlobalUsings.CreateReply();
        var reply2 = GlobalUsings.CreateReply();
        reply1.AddReply(reply2);

        // Act
        reply1.RemoveReply(reply2);

        // Assert
        Assert.DoesNotContain(reply2, reply1.Replies);
    }

    [Fact]
    public void Test_ToStringWithoutNested()
    {
        // Arrange
        var reply = GlobalUsings.CreateReply();

        // Act
        var result = reply.ToStringWithoutNested();

        // Assert
        Assert.Contains($"developer", result);
    }

    [Fact]
    public void Test_ToString()
    {
        // Arrange
        var reply = GlobalUsings.CreateReply();

        // Act
        var result = reply.ToString();

        // Assert
        Assert.Contains($"developer", result);
    }

}
