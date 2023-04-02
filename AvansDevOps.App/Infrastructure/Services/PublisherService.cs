using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;

namespace AvansDevOps.App.Infrastructure.Services;
// OBSERVABLE PATTERN
public class PublisherService
{
    public List<ISubscriber> Subscribers { get; private set; } = new List<ISubscriber>();

    public void AddObserver(ISubscriber subscriber)
    {
        Subscribers.Add(subscriber);
    }

    public void RemoveObserver(ISubscriber subscriber)
    {
        Subscribers.Remove(subscriber);
    }

    public void NotifyObservers(string message, params Person[] userList)
    {
        foreach (var subscriber in Subscribers)
        {
            subscriber.Update(message, userList);
        }
    }
}
