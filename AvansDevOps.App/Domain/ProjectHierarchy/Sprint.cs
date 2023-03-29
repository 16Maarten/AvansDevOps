using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Sprint : Composite
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Status Status { get; set; }
    public ScrumMaster ScrumMaster { get; set; }
    public ICollection<Developer> Developers { get; set; }
    private Pipeline.Pipeline _pipeline { get; set; }

    public Sprint(
        string name,
        DateTime startDate,
        DateTime endDate,
        Status status,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        ScrumMaster = scrumMaster;
        Developers = developers;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitSprint(this);
        base.AcceptVisitor(visitor);
    }
}
