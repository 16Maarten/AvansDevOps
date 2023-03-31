using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain.Pipelines;

public abstract class Pipeline
{
    private PublisherService _publisher;
    private bool _isCancelled = false;

    public Pipeline()
    {
        _publisher = new PublisherService();
    }
    public bool TemplateMethod()
    {
        return Source() && Package() && Build() && Test() && Hook();
    }

    private bool Source()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    private bool Package()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    private bool Build()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    private bool Test()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }
    protected bool Analysis()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    protected bool Deploy()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    protected bool Utility()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    public virtual bool Hook()
    {
        if (_isCancelled) return IsCancelled();
        return true;
    }

    public void Cancel()
    {
        _isCancelled = true;
    }

    private bool IsCancelled()
    {
        _isCancelled = false;
        return false;
    }
}
