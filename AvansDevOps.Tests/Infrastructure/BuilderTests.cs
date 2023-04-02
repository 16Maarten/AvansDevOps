using AvansDevOps.App.Infrastructure.Builders;

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
        // Act
        builder.SetSprints(sprints);
        var buildProject = builder.GetResult();
        // Assert
        Assert.Equal(sprints, buildProject.GetChildren().Cast<Sprint>().ToList());
    }

    [Fact]
    public void Test_SetBacklogItem()
    {
        // Arrange
        var project = new Project("project", new ProductOwner("product", "product owner"));
        var builder = CreateBuilder();
        builder.BuildProject(project);
        List<Developer> developers = new List<Developer>();
        Developer dev = new Developer("Dev");
        developers.Add(dev);
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
        var backlogItems = new List<BacklogItem>();
        var backlogItem = new BacklogItem(1, "story", "story 1", dev, 5);
        backlogItems.Add(backlogItem);
        // Act
        builder.SetSprints(sprints);
        builder.SetBacklogItems(1, backlogItems);
        var buildProject = builder.GetResult();
        // Assert
        var assertSPrint = (Sprint)buildProject.GetComponent(0);
        Assert.Equal(backlogItems, assertSPrint.GetChildren().Cast<BacklogItem>().ToList());
    }

    [Fact]
    public void Test_SetActivities()
    {
        // Arrange
        var project = new Project("project", new ProductOwner("product", "product owner"));
        var builder = CreateBuilder();
        builder.BuildProject(project);
        List<Developer> developers = new List<Developer>();
        Developer dev = new Developer("Dev");
        developers.Add(dev);
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
        var backlogItems = new List<BacklogItem>();
        var backlogItem = new BacklogItem(1, "story", "story 1", dev, 5);
        backlogItems.Add(backlogItem);
        var activities = new List<Activity>();
        var activity1 = new Activity(1, "Inlog pagina", "Maak een inlog pagina", dev, 2);
        var activity2 = new Activity(2, "home pagina", "Maak een home pagina", dev, 3);
        activities.Add(activity1);
        activities.Add(activity2);
        // Act
        builder.SetSprints(sprints);
        builder.SetBacklogItems(1, backlogItems);
        builder.SetActivitys(1, 1, activities);
        var buildProject = builder.GetResult();
        // Assert
        var assertSprint = (Sprint)buildProject.GetComponent(0);
        var assertBacklogitem = (BacklogItem)assertSprint.GetComponent(0);
        Assert.Equal(activities, assertBacklogitem.GetChildren().Cast<Activity>().ToList());
    }
}
