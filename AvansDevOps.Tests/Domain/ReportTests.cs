namespace AvansDevOps.Tests.Domain;

public class ReportTests
{
    [Fact]
    public void Test_Printer_PDF()
    {
        // Arrange
        var report = new Report("Test");
        var mock = new Mock<IPrinter>();
        mock
            .Setup(x => x.Print(It.IsAny<string>()))
            .Returns(true);

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
        var mock = new Mock<IPrinter>();
        mock
            .Setup(x => x.Print(It.IsAny<string>()))
            .Returns(true);

        // Act
        var result = report.Print(PrintFormat.PNG);
        
        // Assert
        Assert.True(result);
    }
}