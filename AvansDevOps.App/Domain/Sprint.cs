namespace AvansDevOps.App.Domain;

public abstract class Sprint
{
    private string _name { get; set; }
    private DateTime _startDate { get; set; }
    private DateTime _endDate { get; set; }
    private Status _status { get; set; }
    private string _pipeline { get; set; }
}
