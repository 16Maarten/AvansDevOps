using System.ComponentModel;
using System.Collections; 

namespace AvansDevOps.App.Domain;

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
    public void acceptVisitor(Visitor visitor)
    {
        foreach (IComponent component in parts)
        {
            component.acceptVisitor(visitor);
        }
    }
}
