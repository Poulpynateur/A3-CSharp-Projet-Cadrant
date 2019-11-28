using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    /// <summary>
    /// Remove a task.
    /// </summary>
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

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Remove the given task.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            int numberDeleted = taskManager.RemoveTask(options["n"]);

            return numberDeleted + " task(s) removed !";
        }
    }
}
