﻿using AvansDevOps.App.Domain.Pipelines;
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
    private Pipeline _pipeline { get; set; }
    private PublisherService _publisherService = new PublisherService();

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
        _publisherService.AddObserver(new NotificationService());
    }

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.VisitSprint(this);
        base.AcceptVisitor(visitor);
    }

    public void CancelRelease()
    {
        Status = Status.Cancelled;
        //Voeg ProductOwner toe aan notificatie-ontvangers
        _publisherService.NotifyObservers($"Release of sprint {Name} is cancelled", ScrumMaster);
    }
    public void Close()
    {
        Status = Status.Closed;
        //Voeg ProductOwner toe aan notificatie-ontvangers
        _publisherService.NotifyObservers($"Sprint {Name} is closed", ScrumMaster);
    }
}
