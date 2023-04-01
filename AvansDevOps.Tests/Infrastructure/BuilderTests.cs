using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Builders;
using System.Runtime.Intrinsics.X86;

namespace AvansDevOps.Tests.Domain;

public class BuilderTests
{
    private IBuilder CreateBuilder()
    {
        return new ProjectBuilder();
    }

    [Fact]
    public void Test_BuildProject()
    {
        // Arrange
        var project = new Project("project", new ProductOwner("product", "product owner"));
        var builder = CreateBuilder();
        // Act
        builder.BuildProject(project);
        var buildProject = builder.GetResult();
        // Assert
        Assert.Equal(project, buildProject);
    }

    //write a test for the method setSprints
    [Fact]
    public void Test_SetSprints()
    {
        // Arrange
        var project = new Project("project", new ProductOwner("product", "product owner"));
        var builder = CreateBuilder();
        builder.BuildProject(project);
        List<Developer> developers = new List<Developer>();
        developers.Add(new Developer("Dev"));
        // Act
        var sprints = new List<Sprint>();
        var sprint = new ReleaseSprint(
            1,
            "Sprint 1",
            DateTime.Now,
            DateTime.Now.AddDays(7),
            new ScrumMaster("Marcel"),
            developers
        );
        sprints.Add(sprint);
        builder.SetSprints(sprints);
        var buildProject = builder.GetResult();
        // Assert
        Assert.Equal(project, buildProject);
    }
}
