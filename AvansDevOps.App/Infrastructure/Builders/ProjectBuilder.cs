using AvansDevOps.App.Domain.ProjectHierarchy;
using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace AvansDevOps.App.Infrastructure.Builders
{
    public class ProjectBuilder : IBuilder
    {
        private Project Project { get; set; }

        public void BuildProject(Project project)
        {
            Project = project;
        }

        public Project GetResult()
        {
            return Project;
        }

        public void SetActivitys(int BacklogItemId, int SprintId, ICollection<Activity> activities)
        {
            var sprints = Project.GetChildren().Cast<Sprint>().ToList();
            if (sprints.Count > 0)
            {
                Sprint sprint = sprints.Find(s => s.Id == SprintId);
                if (sprint != null)
                {
                    var backlogitems = sprint.GetChildren().Cast<BacklogItem>().ToList();
                    if (sprints.Count > 0)
                    {
                        BacklogItem backlogItem = backlogitems.Find(s => s.Id == BacklogItemId);
                        if (backlogItem != null)
                        {
                            foreach (Activity activity in activities)
                            {
                                backlogItem.AddComponent(activity);
                                activity.SetParent(backlogItem);
                            }
                        }
                    }
                }
            }
        }

        public void SetBacklogItems(int SprintId, ICollection<BacklogItem> backlogItems)
        {
            var sprints = Project.GetChildren().Cast<Sprint>().ToList();
            if (sprints.Count > 0)
            {
                Sprint sprint = sprints.Find(s => s.Id == SprintId);
                if (sprint != null)
                {
                    foreach (BacklogItem backlogItem in backlogItems)
                    {
                        sprint.AddComponent(backlogItem);
                        backlogItem.SetParent(sprint);
                    }
                }
            }
        }

        public void SetSprints(ICollection<Sprint> sprints)
        {
            foreach (Sprint sprint in sprints)
            {
                Project.AddComponent(sprint);
                sprint.SetParent(Project);
            }
        }
    }
}
