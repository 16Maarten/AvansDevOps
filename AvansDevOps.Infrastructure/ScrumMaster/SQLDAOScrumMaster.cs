using AvansDevOps.Infrastructure.ScrumMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure.ScrumMaster
{
    public class SQLDAOScrumMaster : IDAOScrumMaster
    {
        public string connectionUrl { get; private set; }

        public SQLDAOScrumMaster(string connectionUrl)
        {
            this.connectionUrl = connectionUrl;
        }

        public bool Create(Domain.ScrumMaster scrumMaster)
        {
            return true;
        }

        public bool Update(Domain.ScrumMaster scrumMaster)
        {
            return true;
        }

        public bool Delete(Domain.ScrumMaster scrumMaster)
        {
            return true;
        }

        public Domain.ScrumMaster Find(int id)
        {
            return new Domain.ScrumMaster("PO1");
        }

        public List<Domain.ScrumMaster> FindAll()
        {
            return new List<Domain.ScrumMaster>();
        }
    }
}
