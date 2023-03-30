using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(
        string name,
        DateTime startDate,
        DateTime endDate,
        Status status,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
        : base(name, startDate, endDate, status, scrumMaster, developers) { }
}
