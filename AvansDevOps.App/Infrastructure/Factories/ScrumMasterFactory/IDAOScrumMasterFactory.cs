using AvansDevOps.App.Domain;

namespace AvansDevOps.App.Infrastructure.Factories.ScrumMasterFactory;

public interface IDAOScrumMasterFactory
{
    bool Create(ScrumMaster scrumMaster);
    bool Update(ScrumMaster scrumMaster);
    bool Delete(ScrumMaster scrumMaster);
    ScrumMaster Find(int id);
    List<ScrumMaster> FindAll();
}
