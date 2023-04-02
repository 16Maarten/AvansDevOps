using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;
// COMPOSITE PATTERN
public abstract class Component
{
    private Component _parent;

    public Component GetParent()
    {
        return _parent;
    }

    public void SetParent(Component parent)
    {
        _parent = parent;
    }

    public abstract void AcceptVisitor(Visitor visitor);
}
