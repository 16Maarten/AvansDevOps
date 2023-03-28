using AvansDevOps.App.DomainServices.FactoryInterfaces;
using AvansDevOps.App.Infrastructure.Factories.DeveloperFactory;
using AvansDevOps.App.Infrastructure.Factories.ProductOwnerFactory;
using AvansDevOps.App.Infrastructure.Factories.ScrumMasterFactory;

namespace AvansDevOps.App.Infrastructure.Factories;

public class SQLDAOFactory : IDAOFactory
{
    public string connectionUrl { get; private set; }

    public SQLDAOFactory(string connectionUrl)
    {
        this.connectionUrl = connectionUrl;
    }

    public IDAODeveloperFactory CreateDeveloperFactory()
    {
        return new SQLDAODeveloperFactory(connectionUrl);
    }

    public IDAOProductOwnerFactory CreateProductOwnerFactory()
    {
        return new SQLDAOProductOwnerFactory(connectionUrl);
    }

    public IDAOScrumMasterFactory CreateScrumMasterFactory()
    {
        return new SQLDAOScrumMasterFactory(connectionUrl);
    }
}
