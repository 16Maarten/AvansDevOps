using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;

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
        return new Developer("Dev");
    }

    public List<Developer> FindAll()
    {
        return new List<Developer>();
    }
}
