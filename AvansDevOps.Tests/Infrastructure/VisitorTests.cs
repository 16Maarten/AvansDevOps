using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;
using AvansDevOps.App.Infrastructure.Builders;
using AvansDevOps.App.Infrastructure.Factories;
using AvansDevOps.App.Infrastructure.Visitors;
using System.Runtime.Intrinsics.X86;

namespace AvansDevOps.Tests.Domain;

public class VisitorTests
{
    private Visitor CreateVisitor()
    {
        return new PrintVisitor();
    }

    //write tests for printvisitor
    [Fact]
    public void Test_PrintVisitor()
    {
        // Arrange
        var visitor = CreateVisitor();
        var project = new Project("project", new ProductOwner("product", "product owner"));
        var builder = new ProjectBuilder();
        builder.BuildProject(project);
        List<Developer> developers = new List<Developer>();
        developers.Add(new Developer("Dev"));
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
        // Act
        buildProject.AcceptVisitor(visitor);
        // Assert
        Assert.Equal("project", "project");
    }
}
