using System.Text;

namespace AvansDevOps.App.Domain.Users;

public abstract class Person
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string SlackId { get; private set; }
    public List<Thread> Threads { get; private set; } = new List<Thread>();
    public List<Reply> Replies { get; private set; } = new List<Reply>();
    public List<string> ContactPreferences { get; private set; } = new List<string>() { "Email", "Slack" };

    public Person(string name) { { Name = name; } }

    public Person(string name, string email, string slackId)
    {
        Name = name;
        Email = email;
        SlackId = slackId;
    }

    public void AddContactPreference(string contactPreference)
    {
        ContactPreferences.Add(contactPreference);
    }

    public void RemoveContactPreference(string contactPreference)
    {
        ContactPreferences.Remove(contactPreference);
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
