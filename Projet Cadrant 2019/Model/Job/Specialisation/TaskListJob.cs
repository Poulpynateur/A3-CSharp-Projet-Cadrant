using EasySave.Helpers;
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
        public override void Execute(Dictionary<string, string> options)
        {
            foreach(Task.Task task in taskManager.Map)
            {
                Output.Display.DisplayText(Statut.STANDARD, task.Name + " : job [" + task.JobName + "] created at " + task.CreatedAt);
            }

            if(taskManager.Map.Count <= 0)
            {
                Output.Display.DisplayText(Statut.INFO, "No task saved.");
            }
        }
    }
}