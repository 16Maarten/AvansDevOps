namespace AvansDevOps.Tests.Domain.Pipelines;

public class TestPipelineTests
{
    [Fact]
    public void TestPipeline_TemplateMethod_ShouldReturnTrue()
    {
        // Arrange
        var testPipeline = new TestPipeline();

        // Act
        var result = testPipeline.TemplateMethod();

        // Assert
        Assert.True(result);
    }
}
