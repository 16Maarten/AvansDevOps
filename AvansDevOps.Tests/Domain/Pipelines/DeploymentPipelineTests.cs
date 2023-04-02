namespace AvansDevOps.Tests.Domain.Pipelines;

public class DeploymentPipelineTests
{
    [Fact]
    public void DeploymentPipelineTests_TemplateMethod_With_Hook__ShouldReturnTrue()
    {
        // Arrange
        var deploymentPipeline = new DeploymentPipeline();

        // Act
        var result = deploymentPipeline.TemplateMethod();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void PipelineTests_Cancel_ShouldReturnTrue()
    {
        // Arrange
        var deploymentPipeline = new DeploymentPipeline();

        // Act
        deploymentPipeline.Cancel();

        // Assert
        Assert.True(deploymentPipeline.PipelineIsCancelled);
    }

    [Fact]
    public void DeploymentPipeline_IsCancelled_ShouldReturnTrue()
    {
        // Arrange
        var deploymentPipeline = new DeploymentPipeline();

        // Act
        var result =  deploymentPipeline.IsCancelled();

        // Assert
        using (new AssertionScope())
        {
            Assert.False(result);
            Assert.False(deploymentPipeline.PipelineIsCancelled);
        }
    }
}
