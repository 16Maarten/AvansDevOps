namespace AvansDevOps.Tests.Domain;

public class ReviewSprintTests
{

    [Fact]
    public void Test_SprintSummary1()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReviewSprint();
        // Act
        var result = sprint.CloseSprint("Sprint is goed gegaan", sprint.ScrumMaster);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_SprintSummary2()
    {
        // Arrange
        var sprint = GlobalUsings.CreateReviewSprint();

        // Act
        var result = sprint.CloseSprint("Sprint is goed gegaan", new Developer("Dev"));
        // Assert
        Assert.False(result);
    }
}
