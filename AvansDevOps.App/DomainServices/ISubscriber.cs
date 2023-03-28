namespace AvansDevOps.App.DomainServices;

public interface ISubscriber<T>
{
    void Update(T notificationObject, string message);
}
