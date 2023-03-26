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
}
