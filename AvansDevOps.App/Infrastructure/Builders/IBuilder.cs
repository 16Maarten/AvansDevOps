namespace AvansDevOps.App.Infrastructure.Builders;

public interface IBuilder
{
    void BuildProject();
    void BuildSprint();
    void BuildBacklogItem();
    void BuildActivity();
}
