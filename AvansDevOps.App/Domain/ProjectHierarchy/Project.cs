using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public class Project : Composite
{
    public string Name { get; set; }
    public ProductOwner ProductOwner { get; set; }

    public Project(string name, ProductOwner productOwner)
    {
        Name = name;
        ProductOwner = productOwner;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitProject(this);
        base.AcceptVisitor(visitor);
    }
}
