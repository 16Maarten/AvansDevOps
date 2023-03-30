namespace AvansDevOps.App.Domain.Pipelines;

public class DeploymentPipeline : Pipeline
{
    public override bool Hook()
    {
        return Analysis() && Deploy() && Utility();
    }
}
