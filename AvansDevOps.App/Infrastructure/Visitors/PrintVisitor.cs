using AvansDevOps.App.Domain.ProjectHierarchy;

namespace AvansDevOps.App.Infrastructure.Visitors;

public class PrintVisitor : Visitor
{
    public override void VisitActivity(Activity activity)
    {
        throw new NotImplementedException();
    }

    public override void VisitBacklogItem(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }

    public override void VisitProject(Project project)
    {
        throw new NotImplementedException();
    }

    public override void VisitSprint(Sprint sprint)
    {
        throw new NotImplementedException();
    }
}
