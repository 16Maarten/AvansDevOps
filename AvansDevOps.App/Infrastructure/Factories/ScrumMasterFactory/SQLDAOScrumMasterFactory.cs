using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;

namespace AvansDevOps.App.Infrastructure.Factories.ScrumMasterFactory;

public class SQLDAOScrumMasterFactory : IDAOScrumMasterFactory
{
    public string connectionUrl { get; private set; }

    public SQLDAOScrumMasterFactory(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public bool Create(ScrumMaster scrumMaster)
    {
        return new SQLDAOScrumMaster(connectionUrl).Create(scrumMaster);
    }

    public bool Update(ScrumMaster scrumMaster)
    {
        return new SQLDAOScrumMaster(connectionUrl).Update(scrumMaster);
    }

    public bool Delete(ScrumMaster scrumMaster)
    {
        return new SQLDAOScrumMaster(connectionUrl).Delete(scrumMaster);
    }

    public ScrumMaster Find(int id)
    {
        return new SQLDAOScrumMaster(connectionUrl).Find(id);
    }

    public List<ScrumMaster> FindAll()
    {
        return new SQLDAOScrumMaster(connectionUrl).FindAll();
    }
}
