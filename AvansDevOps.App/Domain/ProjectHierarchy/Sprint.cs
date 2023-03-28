using AvansDevOps.App.Infrastructure.Visitors;

namespace AvansDevOps.App.Domain.ProjectHierarchy;

public abstract class Sprint : Composite
{
    private string _name { get; set; }
    private DateTime _startDate { get; set; }
    private DateTime _endDate { get; set; }
    private Status _status { get; set; }
    private Pipeline.Pipeline _pipeline { get; set; }

    public Sprint(
        string name,
        DateTime startDate,
        DateTime endDate,
        Status status,
        Pipeline.Pipeline pipeline
    )
    {
        _name = name;
        _startDate = startDate;
        _endDate = endDate;
        _status = status;
        _pipeline = pipeline;
    }

    public void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitSprint(this);
        base.AcceptVisitor(visitor);
    }
}
