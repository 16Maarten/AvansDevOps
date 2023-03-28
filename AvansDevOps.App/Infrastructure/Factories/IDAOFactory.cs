using AvansDevOps.App.Infrastructure.Factories.DeveloperFactory;
using AvansDevOps.App.Infrastructure.Factories.ProductOwnerFactory;
using AvansDevOps.App.Infrastructure.Factories.ScrumMasterFactory;

namespace AvansDevOps.App.Infrastructure.Factories;

public interface IDAOFactory
{
    IDAODeveloperFactory CreateDeveloperFactory();
    IDAOProductOwnerFactory CreateProductOwnerFactory();
    IDAOScrumMasterFactory CreateScrumMasterFactory();
}
