using AvansDevOps.App.Domain;

namespace AvansDevOps.App.Infrastructure.Factories.DeveloperFactory;

public class SQLDAODeveloper : IDAODeveloper
{
    public string connectionUrl { get; private set; }

    public SQLDAODeveloper(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public bool Create(Developer developer)
    {
        return true;
    }

    public bool Update(Developer developer)
    {
        return true;
    }

    public bool Delete(Developer developer)
    {
        return true;
    }

    public Developer Find(int id)
    {
        return new Developer("Dev1");
    }

    public List<Developer> FindAll()
    {
        return new List<Developer>();
    }
}
