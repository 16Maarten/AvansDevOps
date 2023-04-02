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

    public abstract BacklogItemState ToStateToDo(string itemTitle, Person scrumMaster);
    public abstract BacklogItemState ToStateDoing();
    public abstract BacklogItemState ToStateReadyForTesting(string itemTitle, Person tester);
    public abstract BacklogItemState ToStateTesting();
    public abstract BacklogItemState ToStateTested();
    public abstract BacklogItemState ToStateDone();
}
