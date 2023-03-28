using AvansDevOps.App.Domain;
using AvansDevOps.App.DomainServices.FactoryInterfaces;

namespace AvansDevOps.App.Infrastructure.Factories.ScrumMasterFactory;

public class SQLDAOScrumMaster : IDAOScrumMaster
{
    public string connectionUrl { get; private set; }

    public SQLDAOScrumMaster(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public bool Create(ScrumMaster scrumMaster)
    {
        return true;
    }

    public bool Update(ScrumMaster scrumMaster)
    {
        return true;
    }

    public bool Delete(ScrumMaster scrumMaster)
    {
        return true;
    }

    public ScrumMaster Find(int id)
    {
        return new ScrumMaster("PO1");
    }

    public List<ScrumMaster> FindAll()
    {
        return new List<ScrumMaster>();
    }
}
