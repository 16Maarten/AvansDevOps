using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Infrastructure.Visitors;

// VISITOR PATTERN
public class PrintVisitor : Visitor
{
    private string _report;

    public override void VisitActivity(Activity activity)
    {
        _report += "======Activity " + activity.Title + "========\n";
        _report += "Description: " + activity.Description;
        _report += "\nDeveloper: " + activity.Developer.Name;
        if (activity.Tester != null)
        {
            _report += "\nTester: " + activity.Tester.Name;
        }
        _report += "\nStoryPoints: " + activity.StoryPoints + "\n";
    }

    public override void VisitBacklogItem(BacklogItem backlogItem)
    {
        _report += "======BacklogItem " + backlogItem.Title + "========\n";
        _report += "Description: " + backlogItem.Description;
        _report += "\nDeveloper: " + backlogItem.Developer.Name;
        if (backlogItem.Tester != null)
        {
            _report += "\nTester: " + backlogItem.Tester.Name;
        }
        _report += "\nStoryPoints: " + backlogItem.StoryPoints + "\n";
    }

    public override void VisitProject(Project project)
    {
        _report +=
            "======Project "
            + project.Name
            + "========\nProductOwner: "
            + project.ProductOwner.Name
            + "\n";
    }

    public override void VisitSprint(Sprint sprint)
    {
        _report += "======Sprint " + sprint.Name + "========\n";
        _report +=
            "Time: " + sprint.StartDate.ToString() + " - " + sprint.EndDate.ToString() + "\n";
        _report += "Status: " + sprint.Status.ToString();
        _report += "\nScrumMaster: " + sprint.ScrumMaster.Name;
        _report += "\nDevelopers:\n";
        var developers = new List<Developer>(sprint.Developers);
        developers.ForEach(
            dev => _report += dev.Name + " : " + sprint.GetStoryPointsDeveloper(dev) + "\n"
        );
    }

    public string GetReport()
    {
        return _report;
    }
}
