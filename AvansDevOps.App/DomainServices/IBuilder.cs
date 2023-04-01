using AvansDevOps.App.Domain.ProjectHierarchy;

namespace AvansDevOps.App.DomainServices;

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
