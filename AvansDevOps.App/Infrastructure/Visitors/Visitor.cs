using AvansDevOps.App.Domain.ProjectHierarchy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.App.Infrastructure.Visitors
{
    public abstract class Visitor
    {
        public abstract void VisitProject(Project project);
        public abstract void VisitSprint(Sprint sprint);
        public abstract void VisitBacklogItem(BacklogItem backlogItem);
        public abstract void VisitActivity(Activity activity);
    }
}
