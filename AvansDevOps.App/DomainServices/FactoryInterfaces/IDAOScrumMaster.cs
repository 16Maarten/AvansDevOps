using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.DomainServices.FactoryInterfaces;

public interface IDAOScrumMaster
{
    bool Create(ScrumMaster productOwner);
    bool Update(ScrumMaster productOwner);
    bool Delete(ScrumMaster productOwner);
    ScrumMaster Find(int id);
    List<ScrumMaster> FindAll();
}
