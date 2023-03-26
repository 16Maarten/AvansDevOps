using AvansDevOps.Domain;

namespace AvansDevOps.Infrastructure.ScrumMaster
{
    public interface IDAOScrumMasterFactory
    {
        bool Create(Domain.ScrumMaster scrumMaster);
        bool Update(Domain.ScrumMaster scrumMaster);
        bool Delete(Domain.ScrumMaster scrumMaster);
        Domain.ScrumMaster Find(int id);
        List<Domain.ScrumMaster> FindAll();
    }
}
