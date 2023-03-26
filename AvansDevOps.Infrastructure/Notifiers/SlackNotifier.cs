using AvansDevOps.DomainServices;

namespace AvansDevOps.Infrastructure.Notifiers;

public class SlackNotifier<T> : INotifier<T>
{
    public void SendNotification(T notificationObject, string message)
    {
        Console.WriteLine(message);
    }
}