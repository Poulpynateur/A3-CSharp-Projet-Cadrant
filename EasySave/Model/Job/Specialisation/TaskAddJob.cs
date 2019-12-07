using EasySave.Helpers;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Add a task.
    /// </summary>
    class TaskAddJob : BaseJob
    {
        private ITaskManager taskManager;

        public TaskAddJob(ITaskManager taskManager)
        : base("add-task", "Add a task.")
        {
            this.taskManager = taskManager;

            this.Options = new List<Option>
            {
                new Option("t", "Type of the save", @"differential|mirror"),
                new Option("name", "Name of the save", @"^((?![\*\.\/\\\[\]:;\|,]).)*$"),
                new Option("source", "Source folder", @".*"),
                new Option("target", "Target folder", @".*")
            };
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Create a task with <see cref="TaskManager.AddTask(string, string, Dictionary{string, string})"/> function.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            Dictionary<string, string> cmdOptions = new Dictionary<string, string>
            {
                { "name", options["name"] },
                { "source", options["source"] },
                { "target", options["target"] }
            };

            if (options["t"].Equals("differential"))
                taskManager.AddTask(options["name"], "save-differential", cmdOptions);
            else
                taskManager.AddTask(options["name"], "save-mirror", cmdOptions);

            Output.Display.DisplayText(Statut.SUCCESS, "Task "+ options["name"] + " added !");
        }
    }
}
