using AvansDevOps.App.DomainServices;

namespace AvansDevOps.App.Infrastructure.Notifiers;

public class SlackNotifier<T> : INotifier<T>
{
    public void SendNotification(T notificationObject, string message)
    {
        Console.WriteLine(message);
    }
}