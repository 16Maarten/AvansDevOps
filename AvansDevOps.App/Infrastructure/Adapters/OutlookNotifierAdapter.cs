using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Notifiers;

namespace AvansDevOps.App.Infrastructure.Adapters;
// ADAPTER PATTERN
public class OutlookNotifierAdapter : INotifier
{
    private OutlookNotifier _notifier = new OutlookNotifier();
    public OutlookNotifier Notifier
    {
        get { return _notifier; }
        set { _notifier = value; }
    }

    public void SendNotification(string message, Person user)
    {
        _notifier.EmailSendOut(message, user);
    }
}