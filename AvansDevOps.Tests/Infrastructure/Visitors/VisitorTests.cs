namespace AvansDevOps.Tests.Infrastructure.Visitors;

public class VisitorTests
{
    private PrintVisitor CreateVisitor()
    {
        return new PrintVisitor();
    }

    [Fact]
    public void Test_PrintVisitor()
    {
        // Arrange
        var visitor = CreateVisitor();
        var project = new Project("project1", new ProductOwner("product", "product owner"));
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
        var result = visitor.GetReport();
        // Assert
        Assert.True(result.Contains("Marcel"));
    }
}
