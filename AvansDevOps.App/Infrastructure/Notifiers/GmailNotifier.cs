namespace AvansDevOps.App.Infrastructure.Notifiers;

public class GmailNotifier<T>
{
    public void PushEmail(T notificationObject, string message)
    {
        Console.WriteLine(message);
    }
}