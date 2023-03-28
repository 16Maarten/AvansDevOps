using AvansDevOps.App.Domain.ProjectHierarchy;

namespace AvansDevOps.App.Domain;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(
        string name,
        DateTime startDate,
        DateTime endDate,
        Status status,
        Pipeline.Pipeline pipeline
    )
        : base(name, startDate, endDate, status, pipeline) { }
}
