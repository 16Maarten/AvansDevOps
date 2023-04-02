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
    public void Test_RunPipeline_Fail()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();
        var subscriberMock = GlobalUsings.CreateSubscriberMock();
        sprint.PublisherService.AddObserver(subscriberMock.Object);
        sprint.Pipeline.Cancel();

        // Act
        sprint.RunPipeline();

        // Assert
        using (new AssertionScope())
        {
            Assert.Equal(Status.Open, sprint.Status);
            subscriberMock.Verify(x => x.Update(It.Is<string>(x => x.Contains($"Pipeline {sprint.Name} failed")), It.IsAny<Person[]>()), Times.Once);
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
        var subscriberMock = GlobalUsings.CreateSubscriberMock();
        sprint.PublisherService.AddObserver(subscriberMock.Object);

        // Act
        sprint.Close();

        // Assert

        using (new AssertionScope())
        {
            Assert.Equal(Status.Closed, sprint.Status);
            subscriberMock.Verify(x => x.Update(It.Is<string>(x => x.Contains($"Sprint {sprint.Name} is closed")), It.IsAny<Person[]>()), Times.Once);
        }
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

    [Fact]
    public void Test_GetStoryPointsDeveloper2()
    {
        // Arrange
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
    public void Test_RestartPipeline()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();
        sprint.PipelineRunning = true;

        // Act
        sprint.RestartPipeline(sprint.ScrumMaster);

        // Assert
        Assert.Equal(Status.Closed, sprint.Status);
    }

    [Fact]
    public void Test_RestartPipeline_NotAuthorized()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();
        sprint.PipelineRunning = true;

        // Act
        sprint.RestartPipeline(new Developer("dev"));

        // Assert
        Assert.Equal(Status.Open, sprint.Status);
    }

    [Fact]
    public void Test_IsAuthorized()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();

        // Act
        var result = sprint.IsAuthorized(sprint.ScrumMaster);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_IsAuthorized_False()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReleaseSprint();

        // Act
        var result = sprint.IsAuthorized(new Developer("Dev"));

        // Assert
        Assert.False(result);
    }
}
