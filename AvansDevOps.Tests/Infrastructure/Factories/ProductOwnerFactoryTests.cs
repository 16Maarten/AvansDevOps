namespace AvansDevOps.Tests.Infrastructure.Factories;

public class ProductOwnerFactoryTests
{
    private IDAOProductOwnerFactory CreateFactory()
    {
        return new SQLDAOFactory("url").CreateProductOwnerFactory();
    }

    [Fact]
    public void Test_CreateProductOwnerFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ProductOwner po = new ProductOwner("PO1", "Product");
        // Act
        var result = factory.Create(po);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_UpdateProductOwnerFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ProductOwner po = new ProductOwner("PO1", "Product");
        // Act
        var result = factory.Update(po);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_RemoveProductOwnerFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ProductOwner po = new ProductOwner("PO1", "Product");
        // Act
        var result = factory.Delete(po);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_GetProductOwnerFactory()
    {
        // Arrange
        var factory = CreateFactory();
        ProductOwner po = new ProductOwner("PO1", "Product");
        // Act
        var result = factory.Find(1);
        // Assert
        Assert.Equal(result.Name, po.Name);
    }

    [Fact]
    public void Test_GetAllScrumMasterProductOwnerFactory()
    {
        // Arrange
        var factory = CreateFactory();
        // Act
        var result = factory.FindAll();
        // Assert
        Assert.Empty(result);
    }
}
