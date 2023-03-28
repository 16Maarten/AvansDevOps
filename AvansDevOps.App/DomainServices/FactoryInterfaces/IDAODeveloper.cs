using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.DomainServices.FactoryInterfaces;

public interface IDAODeveloper
{
    bool Create(Developer developer);
    bool Update(Developer developer);
    bool Delete(Developer developer);
    Developer Find(int id);
    List<Developer> FindAll();
}
