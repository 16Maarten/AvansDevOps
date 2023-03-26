using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States
{
    public interface IBacklogItemState
    {
        IBacklogItemState StateToDo();
        IBacklogItemState StateDoing();
        IBacklogItemState StateReadyForTesting();
        IBacklogItemState StateTesting();
        IBacklogItemState StateTested();
        IBacklogItemState StateDone();
    }
}
