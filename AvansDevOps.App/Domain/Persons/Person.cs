using System.Text;

namespace AvansDevOps.App.Domain.Users;

public abstract class Person
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string SlackId { get; private set; }
    public List<Thread> Threads { get; private set; } = new List<Thread>();
    public List<Reply> Replies { get; private set; } = new List<Reply>();

    public Person(string name)
    {
        this.Name = name;
    }

    public string ThreadsToString()
    {
        var nestedThreads = new StringBuilder();
        foreach (Thread thread in Threads)
        {
            nestedThreads.AppendLine(thread.ToStringWithoutNested());
        }

        return nestedThreads.ToString();
    }

    public string RepliesToString()
    {
        var nestedReplies = new StringBuilder();
        foreach (Reply reply in Replies)
        {
            nestedReplies.AppendLine(reply.ToStringWithoutNested());
        }

        return nestedReplies.ToString();
    }
}
