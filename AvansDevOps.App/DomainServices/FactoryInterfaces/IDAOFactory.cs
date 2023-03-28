namespace AvansDevOps.App.DomainServices.FactoryInterfaces;

public interface IDAOFactory
{
    IDAODeveloperFactory CreateDeveloperFactory();
    IDAOProductOwnerFactory CreateProductOwnerFactory();
    IDAOScrumMasterFactory CreateScrumMasterFactory();
}
