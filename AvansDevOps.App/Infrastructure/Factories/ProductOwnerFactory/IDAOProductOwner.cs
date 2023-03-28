using AvansDevOps.App.Domain;

namespace AvansDevOps.App.Infrastructure.Factories.ProductOwnerFactory;

public interface IDAOProductOwner
{
    bool Create(ProductOwner productOwner);
    bool Update(ProductOwner productOwner);
    bool Delete(ProductOwner productOwner);
    ProductOwner Find(int id);
    List<ProductOwner> FindAll();
}
