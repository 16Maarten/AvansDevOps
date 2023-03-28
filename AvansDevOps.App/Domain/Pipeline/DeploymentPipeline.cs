namespace AvansDevOps.App.Domain.Pipeline;

public class DeploymentPipeline : Pipeline
{
    public override bool Hook()
    {
        return Analysis() && Deploy() && Utility();
    }
}
