using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.DomainServices.FactoryInterfaces;
using AvansDevOps.App.Infrastructure.Builders;
using AvansDevOps.App.Infrastructure.Factories;
using System.Runtime.Intrinsics.X86;

namespace AvansDevOps.Tests.Domain;

public class DeveloperFactoryTests
{
    private IDAODeveloperFactory CreateFactory()
    {
        return new SQLDAOFactory("url").CreateDeveloperFactory();
    }

    [Fact]
    public void Test_CreateDeveloperFactory()
    {
        // Arrange
        var factory = CreateFactory();
        Developer dev = new Developer("Dev");
        // Act
        var result = factory.Create(dev);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_UpdateDeveloperFactory()
    {
        // Arrange
        var factory = CreateFactory();
        Developer dev = new Developer("Dev");
        // Act
        var result = factory.Update(dev);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_RemoveDeveloperFactory()
    {
        // Arrange
        var factory = CreateFactory();
        Developer dev = new Developer("Dev");
        // Act
        var result = factory.Delete(dev);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_GetDeveloperFactory()
    {
        // Arrange
        var factory = CreateFactory();
        Developer dev = new Developer("Dev");
        // Act
        var result = factory.Find(1);
        // Assert
        Assert.Equal(result.Name, dev.Name);
    }

    [Fact]
    public void Test_GetAllDeveloperFactory()
    {
        // Arrange
        var factory = CreateFactory();
        // Act
        var result = factory.FindAll();
        // Assert
        Assert.Empty(result);
    }
}
