global using AvansDevOps.App.Domain;
global using AvansDevOps.App.Domain.GitStates;
global using AvansDevOps.App.Domain.ProjectHierarchy;
global using AvansDevOps.App.Domain.Users;
global using AvansDevOps.App.Domain.WorkItemStates;
global using AvansDevOps.App.DomainServices;
global using FluentAssertions.Execution;
global using Moq;
global using System.Drawing;
global using Xunit;
global using Thread = AvansDevOps.App.Domain.Thread;


public class GlobalUsings
{
    public static Dictionary<string, List<string>> CreateCommits()
    {
        return new Dictionary<string, List<string>>()
        {
            {"commit1", new List<string>(){"code1", "code2"}},
            {"commit2", new List<string>(){"code3", "code4"}},
            {"commit3", new List<string>(){"code5", "code6"}},
        };
    }

    public static List<string> CreateChanges()
    {
        return new List<string>() { "code1", "code2", "code3", "code4", "code5", "code6"};
    }

    public static Thread CreateThread()
    {
        return new Thread("title", "message", new Developer("developer"), new BacklogItem(1, "backlogItem", "description", new Developer("developer"), 20), new List<Developer>());
    }


    public static BacklogItem CreateBacklogItem()
    {
        var sprint = CreateReleaseSprint();
        var developer = new Developer("developer");
        var backlogItem = new BacklogItem(1, "story", "story 1", developer, 5);
        backlogItem.SetParent(sprint);
        backlogItem.Tester = developer;
        return backlogItem;
    }

    
    public static ReleaseSprint CreateReleaseSprint()
    {
        var sprint = new ReleaseSprint(
            1,
            "Sprint 1",
            DateTime.Now,
            DateTime.Now.AddDays(14),
            new ScrumMaster("ScrumMaster"),
            new List<Developer>()
        );
        sprint.SetParent(new Project("project", new ProductOwner("product", "product owner")));
        sprint.SetPipeLine("test");
        return sprint;
    }

    public static ReviewSprint CreateReviewSprint()
    {
        return new ReviewSprint(
            1,
            "Sprint 1",
            DateTime.Now,
            DateTime.Now.AddDays(14),
            new ScrumMaster("ScrumMaster"),
            new List<Developer>()
        );
    }


    public static ReportAddition CreateReportAddition()
    {
        return new ReportAddition("companyName", "projectName", "version", new Bitmap(1, 1), DateTime.Now);
    }
}