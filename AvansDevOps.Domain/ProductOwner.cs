using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class ProductOwner : Person
    {
        public string product { get; private set; }
        public ProductOwner(string name, string product) : base(name)
        {
            this.product = product;
        }
    }
}
