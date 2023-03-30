using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using System.Diagnostics;

namespace AvansDevOps.App.Infrastructure.Builders;

public interface IBuilder
{
    public void BuildProject(Project project);
    public void SetSprints(ICollection<Sprint> sprints);
    public void SetBacklogItems(int SprintId, ICollection<BacklogItem> backlogItems);
    public void SetActivitys(
        int BacklogItemId,
        int SprintId,
        ICollection<Domain.ProjectHierarchy.Activity> activities
    );
    public Project GetResult();
}
