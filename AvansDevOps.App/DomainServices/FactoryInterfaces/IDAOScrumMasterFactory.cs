using AvansDevOps.App.Domain;

namespace AvansDevOps.App.DomainServices.FactoryInterfaces;

public interface IDAOScrumMasterFactory
{
    bool Create(ScrumMaster scrumMaster);
    bool Update(ScrumMaster scrumMaster);
    bool Delete(ScrumMaster scrumMaster);
    ScrumMaster Find(int id);
    List<ScrumMaster> FindAll();
}
