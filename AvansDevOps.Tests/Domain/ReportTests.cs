namespace AvansDevOps.Tests.Domain;

public class ReportTests
{
    [Fact]
    public void Test_Printer_PDF()
    {
        // Arrange
        var report = new Report("Test");

        // Act
        var result = report.Print(PrintFormat.PDF);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_Printer_PNG()
    {
        // Arrange
        var report = new Report("Test");

        // Act
        var result = report.Print(PrintFormat.PNG);

        // Assert
        Assert.True(result);
    }
}