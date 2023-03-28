using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Composite : IComponent
{
    private List<IComponent> parts;

    public Composite()
    {
        parts = new List<IComponent>();
    }

    public IComponent getComponent(int i)
    {
        return parts.ElementAt(i);
    }

    public void addComponent(IComponent comp)
    {
        parts.Add(comp);
    }

    public void removeComponent(IComponent comp)
    {
        parts.Remove(comp);
    }

    public void AcceptVisitor(Visitor visitor)
    {
        foreach (IComponent component in parts)
        {
            component.AcceptVisitor(visitor);
        }
    }
}
