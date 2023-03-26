using AvansDevOps.DomainServices;
using AvansDevOps.Infrastructure.Notifiers;

namespace AvansDevOps.Infrastructure.Adapters;

public abstract class OutlookNotifierAdapter<T> : INotifier<T>
{
    private OutlookNotifier<T> _notifier;
    public void SendNotification(T notificationObject, string message)
    {
        _notifier.EmailSendOut(notificationObject, message);
    }
}