using AvansDevOps.DomainServices;

namespace AvansDevOps.Infrastructure.Services;

public class NotificationService<T> : ISubscriber<T>
{
    private INotifier<T> _notifier { get; set; }
    public INotifier<T> Notifier
    {
        get { return _notifier; }
        set
        {
            _notifier = value;
        }
    }

    public NotificationService(INotifier<T> notifier)
    {
        _notifier = notifier;
    }
    public void Update(T notificationObject, string message)
    {
        _notifier.SendNotification(notificationObject, message);
    }
}
