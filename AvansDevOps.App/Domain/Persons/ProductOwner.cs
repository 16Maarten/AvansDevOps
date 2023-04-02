namespace AvansDevOps.App.Domain.Users;

public class ProductOwner : Person
{
    public string Product { get; private set; }

    public ProductOwner(string name, string product)
        : base(name)
    {
        Product = product;
    }
}
