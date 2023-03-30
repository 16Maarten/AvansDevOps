using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.DomainServices;

public interface INotifier
{
    void SendNotification(string message, Person user);
}
