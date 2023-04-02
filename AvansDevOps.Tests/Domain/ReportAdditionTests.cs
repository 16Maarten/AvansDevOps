namespace AvansDevOps.Tests.Domain;

public class ReportAdditionTests
{
    public ReportAddition CreateReportAddition()
    {
        return new ReportAddition("companyName", "projectName", "version", new Bitmap(1, 1), DateTime.Now);
    }

    [Fact]
    public void Test_CompanyName()
    {
        // Arrange
        var reportAddition = CreateReportAddition();
        var companyName = "companyName";

        // Act
        reportAddition.CompanyName = companyName;

        // Assert
        Assert.Equal(companyName, reportAddition.CompanyName);
    }

    [Fact]
    public void Test_ProjectName()
    {
        // Arrange
        var reportAddition = CreateReportAddition();
        var projectName = "projectName";

        // Act
        reportAddition.ProjectName = projectName;

        // Assert
        Assert.Equal(projectName, reportAddition.ProjectName);
    }

    [Fact]
    public void Test_Version()
    {
        // Arrange
        var reportAddition = CreateReportAddition();
        var version = "version";

        // Act
        reportAddition.Version = version;

        // Assert
        Assert.Equal(version, reportAddition.Version);
    }

    [Fact]
    public void Test_Logo()
    {
        // Arrange
        var reportAddition = CreateReportAddition();
        var logo = new Bitmap(1, 1);

        // Act
        reportAddition.Logo = logo;

        // Assert
        Assert.Equal(logo, reportAddition.Logo);
    }

    [Fact]
    public void Test_Date()
    {
        // Arrange
        var reportAddition = CreateReportAddition();
        var date = DateTime.Now;

        // Act
        reportAddition.Date = date;

        // Assert
        Assert.Equal(date, reportAddition.Date);
    }
}