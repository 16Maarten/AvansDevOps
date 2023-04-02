namespace AvansDevOps.Tests.Domain.ProjectHierarchy;

public class SprintTests
{
    [Fact]
    public void Test_RunPipeline()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();

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
        var sprint = GlobalUsings.CreateReleaseSprint();
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
        var sprint = GlobalUsings.CreateReleaseSprint();

        // Act
        sprint.Close();

        // Assert
        Assert.Equal(Status.Closed, sprint.Status);
    }

    [Fact]
    public void Test_GetStoryPointsDeveloper()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();
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
        var sprint = GlobalUsings.CreateReleaseSprint();
        var developer = new Developer("developer");
        var backlogItem = new BacklogItem(1, "story", "story 1", developer, 5);
        backlogItem.AddComponent(new Activity(1, "story", "story 2", developer, 3));
        sprint.AddComponent(backlogItem);
        // Act
        var result = sprint.GetStoryPointsDeveloper(developer);
        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Test_IsSprintFinished1()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();
        // Act
        var result = sprint.IsSprintFinished();
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Test_IsSprintFinished2()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();
        sprint.EndDate = DateTime.Now.AddDays(-10);
        // Act
        var result = sprint.IsSprintFinished();
        // Assert
        Assert.True(result);
        Assert.Equal(Status.Finished, sprint.Status);
    }

    [Fact]
    public void Test_SprintSummary1()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReviewSprint();
        // Act
        var result = sprint.CloseSprint("Sprint is goed gegaan", sprint.ScrumMaster);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_SprintSummary2()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReviewSprint();

        // Act
        var result = sprint.CloseSprint("Sprint is goed gegaan", new Developer("Dev"));
        // Assert
        Assert.False(result);
    }
}
