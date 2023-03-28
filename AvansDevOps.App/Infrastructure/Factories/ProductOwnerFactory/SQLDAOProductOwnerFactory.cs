using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;

namespace AvansDevOps.App.Infrastructure.Factories.ProductOwnerFactory;

public class SQLDAOProductOwnerFactory : IDAOProductOwnerFactory
{
    public string connectionUrl { get; private set; }

    public SQLDAOProductOwnerFactory(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public bool Create(ProductOwner productOwner)
    {
        return new SQLDAOProductOwner(connectionUrl).Create(productOwner);
    }

    public bool Update(ProductOwner productOwner)
    {
        return new SQLDAOProductOwner(connectionUrl).Update(productOwner);
    }

    public bool Delete(ProductOwner productOwner)
    {
        return new SQLDAOProductOwner(connectionUrl).Delete(productOwner);
    }

    public ProductOwner Find(int id)
    {
        return new SQLDAOProductOwner(connectionUrl).Find(id);
    }

    public List<ProductOwner> FindAll()
    {
        return new SQLDAOProductOwner(connectionUrl).FindAll();
    }
}
