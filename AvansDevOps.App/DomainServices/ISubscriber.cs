using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.DomainServices;

public interface ISubscriber
{
    void Update(string message, Person[] userList);
}
