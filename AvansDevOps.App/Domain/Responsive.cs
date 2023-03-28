﻿using AvansDevOps.App.Domain.Users;
using System.Text;

namespace AvansDevOps.App.Domain;

public abstract class Responsive
{
    private string _message;
    private Person _person;
    private DateTime dateTime = DateTime.Now;
    private List<Reply> _replies = new List<Reply>();

    public Person Person { get { return _person; } set { _person = value; } }

    public Responsive(string message, Person person)
    {
        _person = person;
        _message = message;
    }

    public void AddReply(Reply reply)
    {
        _replies.Add(reply);
        reply._person.Replies.Add(reply);
    }

    public void RemoveReply(Reply reply)
    {
        reply._person.Replies.Remove(reply);
        _replies.Remove(reply);
    }

    public virtual string ToStringWithoutNested()
    {
        return $"   {_message}\n\n   {_person.Name} - {dateTime.ToLongTimeString()} {dateTime.ToLongDateString()}\n   -------";
    }

    public override string ToString()
    {
        var nestedReplies = new StringBuilder();
        foreach (Reply reply in _replies)
        {
            nestedReplies.AppendLine($"   Reply to {_person.Name} -> {reply.ToString()}");
        }

        return $"   {_message}\n\n   ({_person.Name} - {dateTime.ToLongTimeString()} {dateTime.ToLongDateString()})\n   -------\n{nestedReplies.ToString()}";
    }
}