﻿using AvansDevOps.App.Domain.Pipelines;
using AvansDevOps.App.Domain.Users;
using AvansDevOps.App.Infrastructure.Services;
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
    private Pipeline _pipeline { get; set; } = new TestPipeline();
    public PublisherService PublisherService = new PublisherService();
    public bool PipelineRunning { get; set; } = false;

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
    public void CancelPipeline(Person user)
    {
        if (isAuthorized(user))
        {
            _pipeline.Cancel();
            PipelineRunning = false;
        }
    }

    public void RestartPipeline(Person user)
    {
        if (isAuthorized(user))
        {
            _pipeline.Cancel();
            PipelineRunning = false;
            RunPipeline();
        }
    }

    public void Close()
    {
        Status = Status.Closed;
        PublisherService.NotifyObservers($"Sprint {Name} is closed", ScrumMaster, ((Project)this.GetParent()).ProductOwner);
    }

    private bool isAuthorized(Person user)
    {
        return user == ScrumMaster;
    }
}
