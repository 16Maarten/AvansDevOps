using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain;

public class ReviewSprint : Sprint
{
    public ReviewSprint(
        int id,
        string name,
        DateTime startDate,
        DateTime endDate,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
        : base(id, name, startDate, endDate, scrumMaster, developers) { }
}
