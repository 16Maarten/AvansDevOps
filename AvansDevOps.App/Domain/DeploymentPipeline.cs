using AvansDevOps.App.Domain.AbstractClasses;

namespace AvansDevOps.App.Domain;

public class DeploymentPipeline : Pipeline
{
    public override bool Hook()
    {
        return Analysis() && Deploy() && Utility();
    }
}
