namespace AvansDevOps.Tests.Domain.ProjectHierarchy;

public class SprintTests
{
    public ReleaseSprint CreateReleaseSprint()
    {
        var sprint = new ReleaseSprint(
            1,
            "Sprint 1",
            DateTime.Now,
            DateTime.Now,
            new ScrumMaster("ScrumMaster"),
            new List<Developer>()
        );
        sprint.SetParent(new Project("project", new ProductOwner("product", "product owner")));
        sprint.SetPipeLine("test");
        return sprint;
    }

    [Fact]
    public void Test_RunPipeline()
    {
        // Arrange
        var sprint = CreateReleaseSprint();

        // Act
        sprint.RunPipeline();

        // Assert
        using (new AssertionScope())
        {
            Assert.Equal(Status.Closed, sprint.Status);
            Assert.False(sprint.PipelineRunning);
        }
    }

    [Fact]
    public void Test_CancelPipeline()
    {
        // Arrange
        var sprint = CreateReleaseSprint();
        sprint.PipelineRunning = true;

        // Act
        sprint.CancelPipeline(sprint.ScrumMaster);

        // Assert
        Assert.False(sprint.PipelineRunning);
    }

    [Fact]
    public void Test_Close()
    {
        // Arrange
        var sprint = CreateReleaseSprint();

        // Act
        sprint.Close();

        // Assert
        Assert.Equal(Status.Closed, sprint.Status);
    }

    [Fact]
    public void Test_GetStoryPointsDeveloper()
    {
        // Arrange
        var sprint = CreateReleaseSprint();
        var developer = new Developer("developer");
        var backlogItem = new BacklogItem(1, "story", "story 1", developer, 1);
        sprint.AddComponent(backlogItem);
        // Act
        var result = sprint.GetStoryPointsDeveloper(developer);
        // Assert
        Assert.Equal(1, result);
    }

    //wrirte another test for the method GetStoryPointsDeveloper
    [Fact]
    public void Test_GetStoryPointsDeveloper2()
    {
        var sprint = CreateReleaseSprint();
        var developer = new Developer("developer");
        var backlogItem = new BacklogItem(1, "story", "story 1", developer, 5);
        backlogItem.AddComponent(new Activity(1, "story", "story 2", developer, 3));
        sprint.AddComponent(backlogItem);
        // Act
        var result = sprint.GetStoryPointsDeveloper(developer);
        // Assert
        Assert.Equal(8, result);
    }
}
