using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Domain.WorkItemStates;
using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain;

public class Thread : Responsive
{
    private string _title;
    public BacklogItem BacklogItem { get; set; }
    private ICollection<Developer> _developers { get; set; }
    private PublisherService _publisherService = new PublisherService();

    public Thread(string title, string message, Person person, BacklogItem BacklogItem, ICollection<Developer> developers) : base(message, person)
    {
        _title = title;
        this.BacklogItem = BacklogItem;
        _developers = developers;
        _publisherService.AddObserver(new NotificationService());
    }

    public override void AddReply(Reply reply)
    {
        if (ItemIsNotDoneState()) base.AddReply(reply);
        _publisherService.NotifyObservers($"NEW MESSAGE FOR THREAD {_title}\n[{reply.Person.Name}] - {reply.Message}\n{reply.DateTime.ToLongDateString()}");
    }

    public override void RemoveReply(Reply reply)
    {
        if (ItemIsNotDoneState()) base.RemoveReply(reply);
    }

    public override string ToStringWithoutNested()
    {
        return $"------------\nThread: \"{_title}\"\n------------\n{base.ToStringWithoutNested()}";
    }

    public override string ToString()
    {
        return $"------------\nThread: \"{_title}\"\n------------\n{base.ToString()}";
    }

    public bool ItemIsNotDoneState()
    {
        return BacklogItem.SprintBoardState.GetType() != typeof(DoneState);
    }
}
