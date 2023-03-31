using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(
        int id,
        string name,
        DateTime startDate,
        DateTime endDate,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
        : base(id, name, startDate, endDate, scrumMaster, developers) { }

    public void StartRelease(bool resultsPositive)
    {
        if (resultsPositive) RunPipeline();
        else CancelRelease();
    }

    public void CancelRelease()
    {
        Status = Status.Cancelled;
        PublisherService.NotifyObservers($"Release of sprint {Name} is cancelled", ScrumMaster, ((Project)this.GetParent()).ProductOwner);
    }
}
