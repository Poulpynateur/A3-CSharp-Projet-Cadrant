using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    /// <summary>
    /// Add a task.
    /// </summary>
    class TaskAddCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public TaskAddCommand(ITaskManager taskManager)
        : base("add-task", "Add a task.")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>
            {
                { "t", "differential|mirror" },
                { "name", @"^((?![\*\.\/\\\[\]:;\|,]).)*$" },
                { "source", ".*" },
                { "target", ".*" }
            };
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Create a task with <see cref="TaskManager.AddTask(string, string, Dictionary{string, string})"/> function.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
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

            return "Task "+ options["name"] + " added !";
        }
    }
}
