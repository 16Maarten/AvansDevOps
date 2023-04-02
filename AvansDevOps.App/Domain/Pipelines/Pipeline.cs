using AvansDevOps.App.Infrastructure.Services;

namespace AvansDevOps.App.Domain.Pipelines;

public abstract class Pipeline
{
    private PublisherService _publisher;
    public bool PipelineIsCancelled { get; private set; } = false;

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
        return PipelineAction();
    }

    private bool Package()
    {
        return PipelineAction();
    }

    private bool Build()
    {
        return PipelineAction();
    }

    private bool Test()
    {
        return PipelineAction();
    }
    protected bool Analysis()
    {
        return PipelineAction();
    }

    protected bool Deploy()
    {
        return PipelineAction();
    }

    protected bool Utility()
    {
        return PipelineAction();
    }

    public virtual bool Hook()
    {
        return PipelineAction();
    }

    public void Cancel()
    {
        PipelineIsCancelled = true;
    }

    public bool IsCancelled()
    {
        PipelineIsCancelled = false;
        return false;
    }
    public void ResetCancel()
    {
        PipelineIsCancelled = false;
    }

    private bool PipelineAction()
    {
        if (PipelineIsCancelled) return IsCancelled();

        try
        {
            return true;
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return false;
        }
    }
}
