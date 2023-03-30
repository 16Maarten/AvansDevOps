using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Infrastructure.Notifiers;

public class OutlookNotifier
{
    public void EmailSendOut(string message, Person user)
    {
        Console.WriteLine($"Send email by Outlook library with email:: {user.Email} | Message: {message}");
    }
}