namespace AvansDevOps.Tests.Infrastructure.Services;

public class PublisherServiceTests
{
    [Fact]
    public void Test_AddObserver()
    {
        // Arrange
        var service = new PublisherService();
        var subscriberMock = GlobalUsings.CreateSubscriberMock().Object;

        // Act
        service.AddObserver(subscriberMock); ;

        // Assert
        Assert.Contains(subscriberMock, service.Subscribers);
    }

    [Fact]
    public void Test_RemoveObserver()
    {
        // Arrange
        var service = new PublisherService();
        var subscriberMock = GlobalUsings.CreateSubscriberMock().Object;
        service.AddObserver(subscriberMock);

        // Act
        service.RemoveObserver(subscriberMock);

        // Assert
        Assert.DoesNotContain(subscriberMock, service.Subscribers);
    }

    [Fact]
    public void Test_NotifyObservers()
    {
        // Arrange
        var service = new PublisherService();
        var subscriberMock = GlobalUsings.CreateSubscriberMock();

        service.AddObserver(subscriberMock.Object);

        // Act
        service.NotifyObservers("message", It.IsAny<Person[]>());

        // Assert
        subscriberMock.Verify(x => x.Update("message", It.IsAny<Person[]>()), Times.Once);
    }
}
