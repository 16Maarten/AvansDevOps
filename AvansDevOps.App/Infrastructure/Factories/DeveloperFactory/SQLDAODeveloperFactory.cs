using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;

namespace AvansDevOps.App.Infrastructure.Factories.DeveloperFactory;

public class SQLDAODeveloperFactory : IDAODeveloperFactory
{
    public string connectionUrl { get; private set; }

    public SQLDAODeveloperFactory(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public bool Create(Developer developer)
    {
        return new SQLDAODeveloper(connectionUrl).Create(developer); ;
    }

    public bool Update(Developer developer)
    {
        return new SQLDAODeveloper(connectionUrl).Update(developer);
    }

    public bool Delete(Developer developer)
    {
        return new SQLDAODeveloper(connectionUrl).Delete(developer);
    }

    public Developer Find(int id)
    {
        return new SQLDAODeveloper(connectionUrl).Find(id);
    }

    public List<Developer> FindAll()
    {
        return new SQLDAODeveloper(connectionUrl).FindAll();
    }
}
