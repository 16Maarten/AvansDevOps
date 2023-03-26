using AvansDevOps.DomainServices;
using AvansDevOps.Infrastructure.Notifiers;

namespace AvansDevOps.Infrastructure.Adapters;

public abstract class GmailNotifierAdapter<T> : INotifier<T>
{
    private GmailNotifier<T> _notifier = new GmailNotifier<T>();
    public void SendNotification(T notificationObject, string message)
    {
        _notifier.PushEmail(notificationObject, message);
    }
}