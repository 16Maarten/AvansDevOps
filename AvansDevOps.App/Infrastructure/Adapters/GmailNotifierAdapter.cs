using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Notifiers;

namespace AvansDevOps.App.Infrastructure.Adapters;

public abstract class GmailNotifierAdapter<T> : INotifier<T>
{
    private GmailNotifier<T> _notifier = new GmailNotifier<T>();
    public void SendNotification(T notificationObject, string message)
    {
        _notifier.PushEmail(notificationObject, message);
    }
}