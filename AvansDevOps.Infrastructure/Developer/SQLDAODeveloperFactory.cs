using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Infrastructure.Developer
{
    public class SQLDAODeveloperFactory : IDAODeveloperFactory
    {
        public string connectionUrl { get; private set; }

        public SQLDAODeveloperFactory(string connectionUrl)
        {
            this.connectionUrl = connectionUrl;
        }

        public bool Create(Domain.Developer developer)
        {
            return new SQLDAODeveloper(this.connectionUrl).Create(developer); ;
        }

        public bool Update(Domain.Developer developer)
        {
            return new SQLDAODeveloper(this.connectionUrl).Update(developer);
        }

        public bool Delete(Domain.Developer developer)
        {
            return new SQLDAODeveloper(this.connectionUrl).Delete(developer);
        }

        public Domain.Developer Find(int id)
        {
            return new SQLDAODeveloper(this.connectionUrl).Find(id);
        }

        public List<Domain.Developer> FindAll()
        {
            return new SQLDAODeveloper(this.connectionUrl).FindAll();
        }
    }
}
