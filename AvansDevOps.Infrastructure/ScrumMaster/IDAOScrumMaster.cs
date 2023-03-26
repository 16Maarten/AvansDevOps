using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain;

namespace AvansDevOps.Infrastructure.ScrumMaster
{
    public interface IDAOScrumMaster
    {
        bool Create(Domain.ScrumMaster productOwner);
        bool Update(Domain.ScrumMaster productOwner);
        bool Delete(Domain.ScrumMaster productOwner);
        Domain.ScrumMaster Find(int id);
        List<Domain.ScrumMaster> FindAll();
    }
}
