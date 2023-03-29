namespace AvansDevOps.App.Domain.WorkItemStates;

public interface IBacklogItemState
{
    IBacklogItemState ToStateToDo();
    IBacklogItemState ToStateDoing();
    IBacklogItemState ToStateReadyForTesting();
    IBacklogItemState ToStateTesting();
    IBacklogItemState ToStateTested();
    IBacklogItemState ToStateDone();
}
