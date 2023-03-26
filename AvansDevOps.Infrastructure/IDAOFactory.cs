using AvansDevOps.Infrastructure.Developer;
using AvansDevOps.Infrastructure.ProductOwner;
using AvansDevOps.Infrastructure.ScrumMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure
{
    public interface IDAOFactory
    {
        IDAODeveloperFactory CreateDeveloperFactory();
        IDAOProductOwnerFactory CreateProductOwnerFactory();
        IDAOScrumMasterFactory CreateScrumMasterFactory();
    }
}
