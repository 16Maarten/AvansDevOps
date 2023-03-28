using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public class Project : Composite
{
    private string _name;

    public Project(string name)
    {
        _name = name;
    }

    public void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitProject(this);
        base.AcceptVisitor(visitor);
    }
}
