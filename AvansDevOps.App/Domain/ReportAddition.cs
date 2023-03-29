using System.Drawing;

namespace AvansDevOps.App.Domain;

public class ReportAddition
{
    private string _companyName { get; set; }
    private string _projectName { get; set; }
    private string _version{ get; set; }
    private Image _logo{ get; set; }
    private DateTime _date { get; set; }

    public ReportAddition(string companyName, string projectName, string version, Image logo, DateTime date)
    {
        _companyName = companyName;
        _projectName = projectName;
        _version = version;
        _logo = logo;
        _date = date;
    }

    public override string ToString()
    {
        return $"{_companyName} - {_projectName} - {_version} - {_logo.ToString()} - {_date.ToLocalTime()}"; 
    }
}
