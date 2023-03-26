using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure.ProductOwner
{
    public class SQLDAOProductOwner : IDAOProductOwner
    {
        public string connectionUrl { get; private set; }

        public SQLDAOProductOwner(string connectionUrl)
        {
            this.connectionUrl = connectionUrl;
        }

        public bool Create(Domain.ProductOwner productOwner)
        {
            return true;
        }

        public bool Update(Domain.ProductOwner productOwner)
        {
            return true;
        }

        public bool Delete(Domain.ProductOwner productOwner)
        {
            return true;
        }

        public Domain.ProductOwner Find(int id)
        {
            return new Domain.ProductOwner("PO1","Product");
        }

        public List<Domain.ProductOwner> FindAll()
        {
            return new List<Domain.ProductOwner>();
        }
    }
}
