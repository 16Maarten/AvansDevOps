using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Component
{
    public abstract void AcceptVisitor(Visitor visitor);
}
