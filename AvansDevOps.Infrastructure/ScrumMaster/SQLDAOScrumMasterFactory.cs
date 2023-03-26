using AvansDevOps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure.ScrumMaster
{
    public class SQLDAOScrumMasterFactory : IDAOScrumMasterFactory
    {
        public string connectionUrl { get; private set; }

        public SQLDAOScrumMasterFactory(string connectionUrl)
        {
            this.connectionUrl = connectionUrl;
        }

        public bool Create(Domain.ScrumMaster scrumMaster)
        {
            return new SQLDAOScrumMaster(connectionUrl).Create(scrumMaster);  
        }

        public bool Update(Domain.ScrumMaster scrumMaster)
        {
            return new SQLDAOScrumMaster(connectionUrl).Update(scrumMaster);
        }

        public bool Delete(Domain.ScrumMaster scrumMaster)
        {
            return new SQLDAOScrumMaster(connectionUrl).Delete(scrumMaster);
        }

        public Domain.ScrumMaster Find(int id)
        {
            return new SQLDAOScrumMaster(connectionUrl).Find(id);
        }

        public List<Domain.ScrumMaster> FindAll()
        {
            return new SQLDAOScrumMaster(connectionUrl).FindAll();
        }
    }
}
