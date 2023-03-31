using AvansDevOps.App.Domain.Pipelines;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Services;
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
    private Pipeline _pipeline { get; set; } = new TestPipeline();
    public PublisherService PublisherService = new PublisherService();
    private bool PipelineRunning = false;

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
        PublisherService.AddObserver(new NotificationService());
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitSprint(this);
        base.AcceptVisitor(visitor);
    }

    public void SetPipeLine(string pipeline)
    {
        if (!PipelineRunning)
        {
            if (pipeline == "deploy") _pipeline = new DeploymentPipeline();
            else if (pipeline == "test") _pipeline = new TestPipeline();
            else throw new Exception("Pipeline not found");
        }
    }

    public void RunPipeline()
    {
        PipelineRunning = true;
        if (_pipeline.TemplateMethod()) Close();
        else PublisherService.NotifyObservers($"Pipeline {Name} failed", ScrumMaster);
        PipelineRunning = false;
    }

    public void Close()
    {
        Status = Status.Closed;
        //Voeg ProductOwner toe aan notificatie-ontvangers
        PublisherService.NotifyObservers($"Sprint {Name} is closed", ScrumMaster);
    }
}
