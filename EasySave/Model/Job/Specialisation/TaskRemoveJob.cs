﻿using EasySave.Helpers;
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

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="taskManager">ITaskManager</param>
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
        /// <param name="options">Dictionary of options needed to remove the task</param>
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

            management.Display.DisplayText(Statut.SUCCESS, numberDeleted + management.Lang.Translate(" task(s) removed !"));
        }
    }
}
