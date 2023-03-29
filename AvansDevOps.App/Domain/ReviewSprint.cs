using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain;

public class ReviewSprint : Sprint
{
    public ReviewSprint(
        string name,
        DateTime startDate,
        DateTime endDate,
        Status status,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
        : base(name, startDate, endDate, status, scrumMaster, developers) { }
}
