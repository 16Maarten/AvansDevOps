using AvansDevOps.DomainServices;

namespace AvansDevOps.Infrastructure.Services;

public class PublisherService<T>
{
    private List<ISubscriber<T>> _subscribers = new List<ISubscriber<T>>();

    public void AddObserver(ISubscriber<T> subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void DeleteObserver(ISubscriber<T> subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifyObservers(T notificationObject, string message)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(notificationObject, message);
        }
    }
}
