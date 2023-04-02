using AvansDevOps.App.Domain;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Adapters;
using AvansDevOps.App.Infrastructure.Notifiers;

namespace AvansDevOps.App.Infrastructure.Services;

public class NotificationService : ISubscriber
{
    private INotifier _notifier { get; set; }
    public INotifier Notifier
    {
        get { return _notifier; }
        set { _notifier = value; }
    }
    public bool Update(string message, Person[] userList)
    {
        foreach (var user in userList)
        {
            if (user.ContactPreferences.Contains(ContactPreference.Email))
            {

                _notifier = new OutlookNotifierAdapter();
                _notifier.SendNotification(message, user);
            }

            if (user.ContactPreferences.Contains(ContactPreference.Slack))
            {
                _notifier = new SlackNotifier();
                _notifier.SendNotification(message, user);
            }
        }

        return true;
    }
}
