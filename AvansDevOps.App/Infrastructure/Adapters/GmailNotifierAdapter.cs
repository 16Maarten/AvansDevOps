using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Notifiers;

namespace AvansDevOps.App.Infrastructure.Adapters;

public class GmailNotifierAdapter : INotifier
{
    private GmailNotifier _notifier = new GmailNotifier();
    public void SendNotification(string message, Person user)
    {
        _notifier.PushEmail(message, user);
    }
}