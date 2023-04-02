using AvansDevOps.App.DomainServices.FactoryInterfaces;
using AvansDevOps.App.Infrastructure.Factories;

namespace AvansDevOps.Tests.Domain;

public class ScrumMasterFactoryTests
{
    private IDAOScrumMasterFactory CreateFactory()
    {
        return new SQLDAOFactory("url").CreateScrumMasterFactory();
    }

    [Fact]
    public void Test_CreateScrumMasterFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ScrumMaster sm = new ScrumMaster("SM");
        // Act
        var result = factory.Create(sm);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_UpdateScrumMasterFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ScrumMaster sm = new ScrumMaster("SM");
        // Act
        var result = factory.Update(sm);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_RemoveScrumMasterFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ScrumMaster sm = new ScrumMaster("SM");
        // Act
        var result = factory.Delete(sm);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_GetScrumMasterFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ScrumMaster sm = new ScrumMaster("SM");
        // Act
        var result = factory.Find(1);
        // Assert
        Assert.Equal(result.Name, sm.Name);
    }

    [Fact]
    public void Test_GetAllScrumMasterFactory()
    {
        // Arrange
        var factory = CreateFactory();
        // Act
        var result = factory.FindAll();
        // Assert
        Assert.Empty(result);
    }
}
