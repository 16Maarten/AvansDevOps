using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Domain.WorkItemStates;
using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain;

public class Thread : Responsive
{
    public string Title { get; private set; }
    public BacklogItem BacklogItem { get; set; }
    private ICollection<Developer> _developers { get; set; }
    public PublisherService PublisherService { get; private set; } = new PublisherService();

    public Thread(string title, string message, Person person, BacklogItem BacklogItem, ICollection<Developer> developers) : base(message, person)
    {
        Title = title;
        this.BacklogItem = BacklogItem;
        _developers = developers;
        PublisherService.AddObserver(new NotificationService());
    }

    public override void AddReply(Reply reply)
    {
        if (ItemIsNotDoneState())
        {
            base.AddReply(reply);
            PublisherService.NotifyObservers($"NEW MESSAGE FOR THREAD {Title}\n[{reply.Person.Name}] - {reply.Message}\n{reply.DateTime.ToLongDateString()}", _developers.ToArray());
        }

    }

    public override void RemoveReply(Reply reply)
    {
        if (ItemIsNotDoneState()) base.RemoveReply(reply);
    }

    public override string ToStringWithoutNested()
    {
        return $"------------\nThread: \"{Title}\"\n------------\n{base.ToStringWithoutNested()}";
    }

    public override string ToString()
    {
        return $"------------\nThread: \"{Title}\"\n------------\n{base.ToString()}";
    }

    public bool ItemIsNotDoneState()
    {
        return BacklogItem.SprintBoardState.GetType() != typeof(DoneState);
    }
}
