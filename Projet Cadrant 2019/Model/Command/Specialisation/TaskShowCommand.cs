using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    class TaskShowCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public TaskShowCommand(ITaskManager taskManager) : base(Type.Standard, "show-tasks", "Show the list of tasks.")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>();
        }

        public override void Execute(Dictionary<string, string> options)
        {
            foreach(ITask task in taskManager.Map)
            {
                updateCmdState(State.Processing, task.Name);
            }

            updateCmdState(State.Success, "Done.");
        }
    }
}
