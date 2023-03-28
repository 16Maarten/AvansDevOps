using AvansDevOps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.App.Domain
{
    public abstract class Visitor
    {
        public abstract void visitProject(Project project);
        public abstract void visitSprint(Sprint sprint);
        public abstract void visitBacklogItem(BacklogItem backlogItem);
        public abstract void visitActivity(Activity activity);

    }
}
