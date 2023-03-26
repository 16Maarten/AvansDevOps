using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure.Developer
{
    public class SQLDAODeveloper : IDAODeveloper
    {
        public string connectionUrl { get; private set; }

        public SQLDAODeveloper(string connectionUrl)
        {
            this.connectionUrl = connectionUrl;
        }

        public bool Create(Domain.Developer developer)
        {
            return true;
        }

        public bool Update(Domain.Developer developer)
        {
            return true;
        }

        public bool Delete(Domain.Developer developer)
        {
            return true;
        }

        public Domain.Developer Find(int id)
        {
            return new Domain.Developer("Dev1");
        }

        public List<Domain.Developer> FindAll()
        {
            return new List<Domain.Developer>();
        }
    }
}
