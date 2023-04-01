using AvansDevOps.App.Infrastructure.Builders;

namespace AvansDevOps.Tests.Domain;

public class BuilderTests
{
    private IBuilder CreateBuilder()
    {
        return new ProjectBuilder();
    }

    //create tests for the projectbuilder methods
    [Fact]
    public void Test_CreateProject()
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
}
