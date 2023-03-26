using AvansDevOps.Domain.AbstractClasses;

namespace AvansDevOps.Domain;

public class DeploymentPipeline : Pipeline
{
    public override bool Hook()
    {
        return Analysis() && Deploy() && Utility();
    }
}
