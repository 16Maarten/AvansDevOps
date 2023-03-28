namespace AvansDevOps.App.Domain.States;

public interface IBacklogItemState
{
    IBacklogItemState StateToDo();
    IBacklogItemState StateDoing();
    IBacklogItemState StateReadyForTesting();
    IBacklogItemState StateTesting();
    IBacklogItemState StateTested();
    IBacklogItemState StateDone();
}
