using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Domain.WorkItemStates;

namespace AvansDevOps.App.Domain;

public class Thread : Responsive
{
    private string _title;
    public BacklogItem BacklogItem { get; set; }

    public Thread(string title, string message, Person person, BacklogItem BacklogItem) : base(message, person)
    {
        _title = title;
        this.BacklogItem = BacklogItem;
    }

    public override void AddReply(Reply reply)
    {
        if (ItemIsNotDoneState()) base.AddReply(reply);
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
