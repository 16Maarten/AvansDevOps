namespace AvansDevOps.DomainServices;

public interface INotifier<T>
{
    void SendNotification(T notificationObject, string message);
}
