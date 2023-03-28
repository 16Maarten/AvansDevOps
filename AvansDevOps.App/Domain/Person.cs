namespace AvansDevOps.App.Domain;

public abstract class Person
{
    public string name { get; private set; }

    public Person(string name) {
        this.name = name;   
    }
}
