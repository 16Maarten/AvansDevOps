namespace AvansDevOps.Tests;

public class ForumTests
{
    [Fact]
    public void Test_AddThread()
    {
        // Arrange
        var forum = GlobalUsings.CreateForum();
        var thread = GlobalUsings.CreateThread();

        // Act
        forum.AddThread(thread);

        // Assert
        Assert.Contains(thread, forum.Threads);
    }

    [Fact]
    public void Test_RemoveThread()
    {
        // Arrange
        var forum = GlobalUsings.CreateForum();
        var thread = GlobalUsings.CreateThread();
        forum.AddThread(thread);

        // Act
        forum.RemoveThread(thread);

        // Assert
        Assert.DoesNotContain(thread, forum.Threads);
    }

    [Fact]
    public void Test_ToString()
    {
        // Arrange
        var forum = GlobalUsings.CreateForum();

        // Act
        var result = forum.ToString();

        // Assert
        Assert.Contains($"some forum", result);
    }
}
