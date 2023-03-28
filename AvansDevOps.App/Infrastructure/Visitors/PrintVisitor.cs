using AvansDevOps.App.Domain.ProjectHierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.App.Infrastructure.Visitors
{
    internal class PrintVisitor : Visitor
    {
        public override void VisitActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public override void VisitBacklogItem(BacklogItem backlogItem)
        {
            throw new NotImplementedException();
        }

        public override void VisitProject(Project project)
        {
            throw new NotImplementedException();
        }

        public override void VisitSprint(Sprint sprint)
        {
            throw new NotImplementedException();
        }
    }
}
