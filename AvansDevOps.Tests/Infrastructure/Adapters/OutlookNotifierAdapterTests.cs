namespace AvansDevOps.Tests.Infrastructure.Adapters;

public class OutlookNotifierAdapterTests
{
    [Fact]
    public void Test_EmailSendOut()
    {
        // Arrange
        var outlookNotifierAdapter = new OutlookNotifierAdapter();
        var notifierMock = GlobalUsings.CreateOutlookNotifierMock();
        outlookNotifierAdapter.Notifier = notifierMock.Object;

        // Act
        outlookNotifierAdapter.SendNotification("message", It.IsAny<Person>());

        // Assert
        notifierMock.Verify(x => x.EmailSendOut("message", It.IsAny<Person>()), Times.Once);
    }
}
