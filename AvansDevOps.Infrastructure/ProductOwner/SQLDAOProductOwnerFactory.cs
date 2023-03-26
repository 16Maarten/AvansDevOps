using AvansDevOps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure.ProductOwner
{
    public class SQLDAOProductOwnerFactory : IDAOProductOwnerFactory
    {
        public string connectionUrl { get; private set; }

        public SQLDAOProductOwnerFactory(string connectionUrl)
        {
            this.connectionUrl = connectionUrl;
        }

        public bool Create(Domain.ProductOwner productOwner)
        {
            return new SQLDAOProductOwner(connectionUrl).Create(productOwner);  
        }

        public bool Update(Domain.ProductOwner productOwner)
        {
            return new SQLDAOProductOwner(connectionUrl).Update(productOwner);
        }

        public bool Delete(Domain.ProductOwner productOwner)
        {
            return new SQLDAOProductOwner(connectionUrl).Delete(productOwner);
        }

        public Domain.ProductOwner Find(int id)
        {
            return new SQLDAOProductOwner(connectionUrl).Find(id);
        }

        public List<Domain.ProductOwner> FindAll()
        {
            return new SQLDAOProductOwner(connectionUrl).FindAll();
        }
    }
}
