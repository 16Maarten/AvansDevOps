using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Composite : Component
{
    private List<Component> parts;

    public Composite()
    {
        parts = new List<Component>();
    }

    public Component GetComponent(int i)
    {
        return parts.ElementAt(i);
    }

    public void AddComponent(Component comp)
    {
        parts.Add(comp);
    }

    public void RemoveComponent(Component comp)
    {
        parts.Remove(comp);
    }

    public List<Component> GetChildren()
    {
        return parts;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        foreach (Component component in parts)
        {
            component.AcceptVisitor(visitor);
        }
    }
}
