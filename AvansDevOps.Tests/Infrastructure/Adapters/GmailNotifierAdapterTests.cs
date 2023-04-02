namespace AvansDevOps.Tests.Infrastructure.Adapters;

public class GmailNotifierAdapterTests
{
    [Fact]
    public void Test_SendNotification()
    {
        // Arrange
        var gmailNotifierAdapter = new GmailNotifierAdapter();
        var notifierMock = GlobalUsings.CreateGmailNotifierMock();
        gmailNotifierAdapter.Notifier = notifierMock.Object;

        // Act
        gmailNotifierAdapter.SendNotification("message", It.IsAny<Person>());

        // Assert
        notifierMock.Verify(x => x.PushEmail("message", It.IsAny<Person>()), Times.Once);
    }
}
