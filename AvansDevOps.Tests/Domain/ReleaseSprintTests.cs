namespace AvansDevOps.Tests.Domain;

public class ReleaseSprintTests
{
    [Fact]
    public void Test_StartRelease()
    {
        // Arrange
        var releaseSprint = GlobalUsings.CreateReleaseSprint();

        // Act
        releaseSprint.StartRelease(true);

        // Assert
        Assert.Equal(Status.Closed, releaseSprint.Status);
    }

    [Fact]
    public void Test_StartRelease_Negative_Result()
    {
        // Arrange
        var releaseSprint = GlobalUsings.CreateReleaseSprint();

        // Act
        releaseSprint.StartRelease(false);

        // Assert
        Assert.Equal(Status.Cancelled, releaseSprint.Status);
    }

    [Fact]
    public void Test_CancelRelease()
    {
        // Arrange
        var releaseSprint = GlobalUsings.CreateReleaseSprint();
        var subscriberMock = GlobalUsings.CreateSubscriberMock();

        releaseSprint.PublisherService.AddObserver(subscriberMock.Object);

        // Act
        releaseSprint.CancelRelease();

        // Assert
        using (new AssertionScope())
        {
            Assert.Equal(Status.Cancelled, releaseSprint.Status);
            subscriberMock.Verify(x => x.Update(It.Is<string>(x => x.Contains($"Release of sprint {releaseSprint.Name} is cancelled")), It.IsAny<Person[]>()), Times.Once);
        }
    }

}