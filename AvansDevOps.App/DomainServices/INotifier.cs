namespace AvansDevOps.App.DomainServices;

public interface INotifier<T>
{
    void SendNotification(T notificationObject, string message);
}
