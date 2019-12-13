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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taskManager">ITaskManager object</param>
        public TaskListJob(ITaskManager taskManager)
        : base("list-tasks", "Show the list of tasks.")
        {
            this.taskManager = taskManager;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Show the task list.
        /// </summary>
        /// <param name="options">Dictionary of options needed to execute the tasks</param>
        public override void Execute(Dictionary<string, string> options)
        {
            foreach(Task.Task task in taskManager.Map)
            {
                management.Display.DisplayText(Statut.INFO, task.Name + management.Lang.Translate(" : job [") + task.JobName + management.Lang.Translate("] created at ") + task.CreatedAt);
            }

            if(taskManager.Map.Count <= 0)
            {
                management.Display.DisplayText(Statut.INFO, management.Lang.Translate("No task saved."));
            }
        }
    }
}