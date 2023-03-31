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
        : base(name, startDate, endDate, status, scrumMaster, developers) { }

    public void StartRelease(bool resultsPositive)
    {
        if (resultsPositive) RunPipeline();
        else CancelRelease();
    }

    public void CancelRelease()
    {
        Status = Status.Cancelled;
        //Voeg ProductOwner toe aan notificatie-ontvangers
        PublisherService.NotifyObservers($"Release of sprint {Name} is cancelled", ScrumMaster);
    }
}
