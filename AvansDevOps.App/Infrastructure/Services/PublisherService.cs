using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices;

namespace AvansDevOps.App.Infrastructure.Services;

public class PublisherService
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void AddObserver(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void DeleteObserver(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifyObservers(string message, params Person[] userList)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(message, userList);
        }
    }
}
