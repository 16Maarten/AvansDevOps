using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States
{
    internal class TestingState : IBacklogItemState
    {
        public IBacklogItemState StateDoing()
        {
            Console.WriteLine("Item kan niet naar status doing");
            return new TestingState();
        }

        public IBacklogItemState StateDone()
        {
            Console.WriteLine("Item kan niet naar status done");
            return new TestingState();
        }

        public IBacklogItemState StateReadyForTesting()
        {
            Console.WriteLine("Item kan niet naar status ready for testing");
            return new TestingState();
        }

        public IBacklogItemState StateTested()
        {
            return new TestedState();
        }

        public IBacklogItemState StateTesting()
        {
            Console.WriteLine("Item is al status testing");
            return new TestingState();
        }

        public IBacklogItemState StateToDo()
        {
            return new ToDoState();
        }
    }
}
