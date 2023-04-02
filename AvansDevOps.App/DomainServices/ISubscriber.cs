using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.DomainServices;

public interface ISubscriber
{
    bool Update(string message, Person[] userList);
}
