using AvansDevOps.App.Domain.ProjectHierarchy;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;
using System.Collections.Specialized;

namespace AvansDevOps.App.Domain;

public class ReviewSprint : Sprint
{
    private string _sprintSummary;

    public ReviewSprint(
        int id,
        string name,
        DateTime startDate,
        DateTime endDate,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
        : base(id, name, startDate, endDate, scrumMaster, developers) { }

    public bool FinishSprint(string summary, Person user)
    {
        if (this.IsAuthorized(user))
        {
            _sprintSummary = summary;
            base.Status = Status.Closed;
            return true;
        }
        else
        {
            return false;
        }
    }
}
