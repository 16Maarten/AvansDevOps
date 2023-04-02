using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Composite : Component
{
    private List<Component> _parts;

    public Composite()
    {
        _parts = new List<Component>();
    }

    public Component GetComponent(int i)
    {
        return _parts.ElementAt(i);
    }

    public void AddComponent(Component comp)
    {
        _parts.Add(comp);
    }

    public void RemoveComponent(Component comp)
    {
        _parts.Remove(comp);
    }

    public List<Component> GetChildren()
    {
        return _parts;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        foreach (Component component in _parts)
        {
            component.AcceptVisitor(visitor);
        }
    }
}
