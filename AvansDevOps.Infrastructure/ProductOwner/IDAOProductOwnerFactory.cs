using AvansDevOps.Domain;

namespace AvansDevOps.Infrastructure.ProductOwner
{
    public interface IDAOProductOwnerFactory
    {
        bool Create(Domain.ProductOwner productOwner);
        bool Update(Domain.ProductOwner productOwner);
        bool Delete(Domain.ProductOwner productOwner);
        Domain.ProductOwner Find(int id);
        List<Domain.ProductOwner> FindAll();
    }
}
