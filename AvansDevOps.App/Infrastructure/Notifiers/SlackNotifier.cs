using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;

namespace AvansDevOps.App.Infrastructure.Notifiers;

public class SlackNotifier : INotifier
{
    public void SendNotification(string message, Person user)
    {
        Console.WriteLine($"Slack-ID: {user.SlackId} | Message: {message}");
    }
}