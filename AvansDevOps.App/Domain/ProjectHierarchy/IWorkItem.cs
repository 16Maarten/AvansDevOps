using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.App.Domain.ProjectHierarchy
{
    internal interface IWorkItem
    {
        public void ToTodo();
        public void ToDoing();
        public void ToReadyForTesting();
        public void ToTesting();
        public void ToTested();
        public void ToDone();
    }
}
