using AvansDevOps.Domain;

namespace AvansDevOps.Infrastructure.Developer
{
    public interface IDAODeveloperFactory
    {
        bool Create(Domain.Developer developer);
        bool Update(Domain.Developer developer);
        bool Delete(Domain.Developer developer);
        Domain.Developer Find(int id);
        List<Domain.Developer> FindAll();
    }
}
