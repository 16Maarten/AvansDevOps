using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain.WorkItemStates;

public abstract class BacklogItemState
{
    public PublisherService PublisherService = new PublisherService();

    public BacklogItemState()
    {
        PublisherService.AddObserver(new NotificationService());
    }

    public abstract BacklogItemState ToStateToDo(string itemTile, Person scrumMaster);
    public abstract BacklogItemState ToStateDoing();
    public abstract BacklogItemState ToStateReadyForTesting(string itemTile, Person tester);
    public abstract BacklogItemState ToStateTesting();
    public abstract BacklogItemState ToStateTested();
    public abstract BacklogItemState ToStateDone();
}
