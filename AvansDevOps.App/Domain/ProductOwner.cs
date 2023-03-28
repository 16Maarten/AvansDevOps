namespace AvansDevOps.App.Domain;

public class ProductOwner : Person
{
    public string product { get; private set; }
    public ProductOwner(string name, string product) : base(name)
    {
        this.product = product;
    }
}
