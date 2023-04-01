using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Infrastructure.Visitors;

public class PrintVisitor : Visitor
{
    public override void VisitActivity(Activity activity)
    {
        Console.WriteLine("======Activity " + activity.Title + "========");
        Console.WriteLine("Description: " + activity.Description);
        Console.WriteLine("Developer: " + activity.Developer.Name);
        if (activity.Tester != null)
        {
            Console.WriteLine("Tester: " + activity.Tester.Name);
        }
        Console.WriteLine("StoryPoints: " + activity.StoryPoints);
    }

    public override void VisitBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("======BacklogItem " + backlogItem.Title + "========");
        Console.WriteLine("Description: " + backlogItem.Description);
        Console.WriteLine("Developer: " + backlogItem.Developer.Name);
        if (backlogItem.Tester != null)
        {
            Console.WriteLine("Tester: " + backlogItem.Tester.Name);
        }
        Console.WriteLine("StoryPoints: " + backlogItem.StoryPoints);
    }

    public override void VisitProject(Project project)
    {
        Console.WriteLine("======Project " + project.Name + "========");
        Console.WriteLine("ProductOwner: " + project.ProductOwner.Name);
    }

    public override void VisitSprint(Sprint sprint)
    {
        Console.WriteLine("======Sprint " + sprint.Name + "========");
        Console.WriteLine(
            "Time: " + sprint.StartDate.ToString() + " - " + sprint.EndDate.ToString()
        );
        Console.WriteLine("Status: " + sprint.Status.ToString());
        Console.WriteLine("ScrumMaster: " + sprint.ScrumMaster.Name);
        Console.WriteLine("Developers: ");
        var developers = new List<Developer>(sprint.Developers);
        developers.ForEach(
            dev => Console.WriteLine(dev.Name + " : " + sprint.GetStoryPointsDeveloper(dev))
        );
    }
}
