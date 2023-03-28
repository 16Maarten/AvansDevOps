namespace AvansDevOps.App.Domain;

public interface IComponent
{
    public abstract void acceptVisitor(Visitor visitor);

}
