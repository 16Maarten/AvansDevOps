using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Sprint : Composite
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Status Status { get; set; } = Status.Open;
    public ScrumMaster ScrumMaster { get; set; }
    public ICollection<Developer> Developers { get; set; }
    private Pipeline.Pipeline _pipeline { get; set; }

    public Sprint(
        int id,
        string name,
        DateTime startDate,
        DateTime endDate,
        ScrumMaster scrumMaster,
        ICollection<Developer> developers
    )
    {
        Id = id;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        ScrumMaster = scrumMaster;
        Developers = developers;
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitSprint(this);
        base.AcceptVisitor(visitor);
    }
}
