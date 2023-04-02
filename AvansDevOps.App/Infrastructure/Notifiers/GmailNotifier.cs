using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Infrastructure.Notifiers;

public class GmailNotifier
{
    public virtual void PushEmail(string message, Person user)
    {
        Console.WriteLine($"Send email by Gmail library with email: {user.Email} | Message: {message}");
    }
}