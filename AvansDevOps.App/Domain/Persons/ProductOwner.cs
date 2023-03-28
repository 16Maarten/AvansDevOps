namespace AvansDevOps.App.Domain.Users;

public class ProductOwner : Person
{
    public string product { get; private set; }
    public ProductOwner(string name, string product) : base(name)
    {
        this.product = product;
    }
}
