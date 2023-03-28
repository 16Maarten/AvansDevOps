using AvansDevOps.App.Domain.Users;

namespace AvansDevOps.App.Domain;

public class Thread : Responsive
{
    private string _title;

    public Thread(string title, string message, Person person) : base(message, person) {
        _title = title;        
    }

    public override string ToStringWithoutNested()
    {
        return $"------------\nThread: \"{_title}\"\n------------\n{base.ToStringWithoutNested()}";
    }

    public override string ToString()
    {
        return $"------------\nThread: \"{_title}\"\n------------\n{base.ToString()}";
    }
}
