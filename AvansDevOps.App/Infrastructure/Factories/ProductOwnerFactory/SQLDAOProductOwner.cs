using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;

namespace AvansDevOps.App.Infrastructure.Factories.ProductOwnerFactory;

public class SQLDAOProductOwner : IDAOProductOwner
{
    public string connectionUrl { get; private set; }

    public SQLDAOProductOwner(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public bool Create(ProductOwner productOwner)
    {
        return true;
    }

    public bool Update(ProductOwner productOwner)
    {
        return true;
    }

    public bool Delete(ProductOwner productOwner)
    {
        return true;
    }

    public ProductOwner Find(int id)
    {
        return new ProductOwner("PO1", "Product");
    }

    public List<ProductOwner> FindAll()
    {
        return new List<ProductOwner>();
    }
}
