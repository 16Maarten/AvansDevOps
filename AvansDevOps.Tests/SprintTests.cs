using AvansDevOps.App.Domain;
using AvansDevOps.App.Domain.ProjectHierarchy;
namespace AvansDevOps.Tests;

public class SprintTests
{
    public ReleaseSprint CreateReleaseSprint()
    {
        var sprint = new ReleaseSprint(1, "Sprint 1", DateTime.Now, DateTime.Now, new ScrumMaster("ScrumMaster"), new List<Developer>());
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
}