using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain;

public class Reply : Responsive
{
    public Reply(string message, Person person) : base(message, person) { }
}
