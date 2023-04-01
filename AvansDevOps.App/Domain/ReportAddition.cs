using System.Drawing;

namespace AvansDevOps.App.Domain;

public class ReportAddition
{
    private string _companyName { get; set; }
    private string _projectName { get; set; }
    private string _version { get; set; }
    private Image _logo { get; set; }
    private DateTime _date { get; set; }

    public ReportAddition(string companyName, string projectName, string version, Image logo, DateTime date)
    {
        _companyName = companyName;
        _projectName = projectName;
        _version = version;
        _logo = logo;
        _date = date;
    }

    public string CompanyName
    {
        get => _companyName;
        set => _companyName = value;
    }

    public string ProjectName
    {
        get => _projectName;
        set => _projectName = value;
    }

    public string Version
    {
        get => _version;
        set => _version = value;
    }

    public Image Logo
    {
        get => _logo; set => _logo = value;
    }

    public DateTime Date
    {
        get => _date;
        set => _date = value;
    }

    public override string ToString()
    {
        return $"{_companyName} - {_projectName} - {_version} - {_logo.ToString()} - {_date.ToLocalTime()}";
    }
}
