using System.Text;

namespace AvansDevOps.App.Domain;

public class Forum
{
    private string _name;
    private string _description;
    private List<Thread> _threads = new List<Thread>();

    public Forum(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void AddThread(Thread thread)
    {
        _threads.Add(thread);
        thread.Person.Threads.Add(thread);
    }

    public void RemoveThread(Thread thread)
    {
        thread.Person.Threads.Remove(thread);
        _threads.Remove(thread);
    }

    public override string ToString()
    {
        var threads = new StringBuilder();
        foreach (Thread thread in _threads)
        {
            threads.AppendLine(thread.ToString());
        }

        return $"-----------------------\n[FORUM - {_name.ToUpper()}]\n-----------------------\n{_description}\n-----------------------\n\n{threads.ToString()}";
    }
}
