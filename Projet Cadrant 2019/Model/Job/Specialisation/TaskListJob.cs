using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Show the list of tasks.
    /// </summary>
    class TaskListJob : BaseJob
    {
        private ITaskManager taskManager;

        public TaskListJob(ITaskManager taskManager)
        : base("list-tasks", "Show the list of tasks.")
        {
            this.taskManager = taskManager;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Show the task list.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
        {
            string str = "";

            foreach(Task.Task task in taskManager.Map)
            {
                str += "\n" + task.Name + " : command [" + task.CmdName + "] created at " + task.CreatedAt;
            }

            return str;
        }
    }
}