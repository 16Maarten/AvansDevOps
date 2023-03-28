using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.DomainServices.FactoryInterfaces;

public interface IDAOProductOwnerFactory
{
    bool Create(ProductOwner productOwner);
    bool Update(ProductOwner productOwner);
    bool Delete(ProductOwner productOwner);
    ProductOwner Find(int id);
    List<ProductOwner> FindAll();
}
