using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Notifiers;

namespace AvansDevOps.App.Infrastructure.Adapters;

public abstract class OutlookNotifierAdapter<T> : INotifier<T>
{
    private OutlookNotifier<T> _notifier = new OutlookNotifier<T>();
    public void SendNotification(T notificationObject, string message)
    {
        _notifier.EmailSendOut(notificationObject, message);
    }
}