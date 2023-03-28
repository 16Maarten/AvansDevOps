namespace AvansDevOps.App.Infrastructure.Notifiers;

public class OutlookNotifier<T>
{
    public void EmailSendOut(T notificationObject, string message)
    {
        Console.WriteLine(message);
    }
}