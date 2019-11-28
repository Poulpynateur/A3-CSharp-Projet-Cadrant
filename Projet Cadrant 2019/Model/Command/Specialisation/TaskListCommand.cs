using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    /// <summary>
    /// Show the list of tasks.
    /// </summary>
    class TaskListCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public TaskListCommand(ITaskManager taskManager)
        : base("list-tasks", "Show the list of tasks.")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>();
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Show the task list.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
        {
            string str = "";

            foreach(ITask task in taskManager.Map)
            {
                str += "\n" + task.Info.Name + " : command [" + task.Info.CmdName + "] created at " + task.Info.CreatedAt;
            }

            return str;
        }
    }
}