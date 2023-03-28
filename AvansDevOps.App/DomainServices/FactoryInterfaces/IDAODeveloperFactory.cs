using AvansDevOps.App.Domain;

namespace AvansDevOps.App.DomainServices.FactoryInterfaces;

public interface IDAODeveloperFactory
{
    bool Create(Developer developer);
    bool Update(Developer developer);
    bool Delete(Developer developer);
    Developer Find(int id);
    List<Developer> FindAll();
}
