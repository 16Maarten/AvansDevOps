using System.Reflection.Metadata;

namespace AvansDevOps.Domain.AbstractClasses;

public abstract class Pipeline
{
    private Publisher<Pipeline> _publisher;
    //private User _scrumMaster;

    public Pipeline()
    {
        _publisher = new Publisher<Pipeline>();
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
