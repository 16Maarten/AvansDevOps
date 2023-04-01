using AvansDevOps.App.Domain.Users;
using System.Text;

namespace AvansDevOps.App.Domain;

public abstract class Responsive
{
    public string Message { get; private set; }
    public Person Person { get; private set; }
    public DateTime DateTime { get; private set; } = DateTime.Now;
    public List<Reply> Replies { get; private set; } = new List<Reply>();

    public Responsive(string message, Person person)
    {
        Person = person;
        Message = message;
    }

    public virtual void AddReply(Reply reply)
    {
        Replies.Add(reply);
        reply.Person.Replies.Add(reply);
    }

    public virtual void RemoveReply(Reply reply)
    {
        reply.Person.Replies.Remove(reply);
        Replies.Remove(reply);
    }

    public virtual string ToStringWithoutNested()
    {
        return $"   {Message}\n\n   {Person.Name} - {DateTime.ToLongTimeString()} {DateTime.ToLongDateString()}\n   -------";
    }

    public override string ToString()
    {
        var nestedReplies = new StringBuilder();
        foreach (Reply reply in Replies)
        {
            nestedReplies.AppendLine($"   Reply to {Person.Name} -> {reply.ToString()}");
        }

        return $"   {Message}\n\n   ({Person.Name} - {DateTime.ToLongTimeString()} {DateTime.ToLongDateString()})\n   -------\n{nestedReplies.ToString()}";
    }
}
