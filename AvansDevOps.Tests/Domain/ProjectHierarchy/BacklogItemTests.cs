namespace AvansDevOps.Tests.Domain.ProjectHierarchy;

public class BacklogItemTests
{
    public BacklogItem CreateBacklogItem()
    {
        return new BacklogItem(1, "story", "story 1", new Developer("Dev"), 5);
    }

    [Fact]
    public void Test_StartWithTodo()
    {
        // Act
        var backlogItem = CreateBacklogItem();

        // Assert
        Assert.IsType<ToDoState>(backlogItem.SprintBoardState);
    }
}
