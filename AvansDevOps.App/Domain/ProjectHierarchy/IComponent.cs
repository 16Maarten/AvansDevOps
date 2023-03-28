using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public interface IComponent
{
    public abstract void AcceptVisitor(Visitor visitor);
}
