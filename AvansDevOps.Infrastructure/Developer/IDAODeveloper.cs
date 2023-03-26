using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain;

namespace AvansDevOps.Infrastructure.Developer
{
    public interface IDAODeveloper
    {
        bool Create(Domain.Developer developer);
        bool Update(Domain.Developer developer);
        bool Delete(Domain.Developer developer);
        Domain.Developer Find(int id);
        List<Domain.Developer> FindAll();
    }
}
