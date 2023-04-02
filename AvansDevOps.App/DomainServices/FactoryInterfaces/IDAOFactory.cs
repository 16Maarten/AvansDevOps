namespace AvansDevOps.App.DomainServices.FactoryInterfaces;
// FACTORY PATTERN
public interface IDAOFactory
{
    IDAODeveloperFactory CreateDeveloperFactory();
    IDAOProductOwnerFactory CreateProductOwnerFactory();
    IDAOScrumMasterFactory CreateScrumMasterFactory();
}
