namespace AvansDevOps.App.Domain.Users;

public abstract class Person
{
    public string name { get; private set; }

    public Person(string name)
    {
        this.name = name;
    }
}
