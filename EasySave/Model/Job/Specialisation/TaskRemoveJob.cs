using EasySave.Helpers;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Remove a task.
    /// </summary>
    class TaskRemoveJob : BaseJob
    {
        private ITaskManager taskManager;

        public TaskRemoveJob(ITaskManager taskManager)
        : base("remove-task", "Remove a task.")
        {
            this.taskManager = taskManager;

            this.Options = new List<Option>
            {
                new Option("name", "Name of the task(s) to remove", ".*")
            };
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Remove the given task.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);
            string[] separators = { ";" };
            string[] tasksNames = options["name"].Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int numberDeleted = 0;

            foreach (var task in tasksNames)
            {
                taskManager.RemoveTask(task);
                numberDeleted++;
            }

            output.Display.DisplayText(Statut.SUCCESS, numberDeleted + " task(s) removed !");
        }
    }
}
