using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.App.Infrastructure.Builders
{
    internal interface IBuilder
    {
        void BuildProject();
        void BuildSprint();
        void BuildBAcklogItem();
        void BuildActivity();
    }
}
