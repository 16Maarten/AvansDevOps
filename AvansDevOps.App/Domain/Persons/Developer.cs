namespace AvansDevOps.App.Domain.Users;

public class Developer : Person
{
    public Developer(string name)
        : base(name) { }

    public Developer(string name, string email, string slackId) : base(name, email, slackId)
    {
    }
}
