using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.DomainServices;

namespace AvansDevOps.App.Infrastructure.Builders
{
    public class ProjectBuilder : IBuilder
    {
        private Project _project { get; set; }

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
            var sprint = findSprint(SprintId);
            if (sprint != null)
            {
                BacklogItem backlogItem = findBacklogItem(BacklogItemId, sprint);
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

        public void SetBacklogItems(int SprintId, ICollection<BacklogItem> backlogItems)
        {
            var sprint = findSprint(SprintId);
            if (sprint != null)
            {
                foreach (BacklogItem backlogItem in backlogItems)
                {
                    sprint.AddComponent(backlogItem);
                    backlogItem.SetParent(sprint);
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

        private Sprint findSprint(int SprintId)
        {
            var sprints = Project.GetChildren().Cast<Sprint>().ToList();
            if (sprints.Count > 0)
            {
                return sprints.Find(s => s.Id == SprintId);
            }
            return null;
        }

        private BacklogItem findBacklogItem(int BacklogItemId, Sprint sprint)
        {
            var backlogitems = sprint.GetChildren().Cast<BacklogItem>().ToList();
            if (backlogitems.Count > 0)
            {
                return backlogitems.Find(s => s.Id == BacklogItemId);
            }
            return null;
        }
    }
}
