namespace AvansDevOps.Tests.Infrastructure.Services;

public class NotificationServiceTests
{
    [Fact]
    public void Test_Update()
    {
        // Arrange
        var service = new NotificationService();

        // Act
        var result = service.Update("message", new Person[] { new Developer("dev") });

        // Assert
        Assert.True(result);
    }
}
