using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    class TaskRemoveCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public TaskRemoveCommand(ITaskManager taskManager)
        : base("remove-task", "Remove a task.")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>
            {
                { "n", ".*" }
            };
        }

        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            int numberDeleted = taskManager.RemoveTask(options["n"]);

            return numberDeleted + " task(s) removed !";
        }
    }
}
