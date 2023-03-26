using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain;

namespace AvansDevOps.Infrastructure.ProductOwner
{
    public interface IDAOProductOwner
    {
        bool Create(Domain.ProductOwner productOwner);
        bool Update(Domain.ProductOwner productOwner);
        bool Delete(Domain.ProductOwner productOwner);
        Domain.ProductOwner Find(int id);
        List<Domain.ProductOwner> FindAll();
    }
}
