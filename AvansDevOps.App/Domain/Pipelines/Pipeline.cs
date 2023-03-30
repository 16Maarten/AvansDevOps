using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain.Pipelines;

public abstract class Pipeline
{
    private PublisherService _publisher;
    //private User _scrumMaster;

    public Pipeline()
    {
        _publisher = new PublisherService();
        //_scrumMaster = user;
    }
    public bool TemplateMethod()
    {
        return Source() && Package() && Build() && Test() && Hook();
    }

    private bool Source()
    {
        return true;
    }

    private bool Package()
    {
        return true;
    }

    private bool Build()
    {
        return true;
    }

    private bool Test()
    {
        return true;
    }
    protected bool Analysis()
    {
        return true;
    }

    protected bool Deploy()
    {
        return true;
    }

    protected bool Utility()
    {
        return true;
    }

    public virtual bool Hook()
    {
        return true;
    }
}
