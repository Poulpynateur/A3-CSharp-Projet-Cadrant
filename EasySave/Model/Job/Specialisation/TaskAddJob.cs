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
                new Option("type", "Type of the save", @"differential|mirror"),
                new Option("encrypt", "Encrypt special files", @"yes|no"),
                new Option("name", "Name of the save", @"^((?![\*\.\/\\\[\]:;\|,]).)*$"),
                new Option("source", "Source folder", @".*"),
                new Option("target", "Target folder", @".*")
            };
        }

        private string GetUniqueName(string wantedName)
        {
            int i = 1;
            string name = (String.IsNullOrEmpty(wantedName))? "Unamed" : wantedName ;

            while(taskManager.GetTaskByName(name) != null)
            {
                name = wantedName + " " + i;
                i++;
            }

            return name;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Create a task with <see cref="TaskManager.AddTask(string, string, Dictionary{string, string})"/> function.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            string name = GetUniqueName(options["name"]);
            Dictionary<string, string> cmdOptions = new Dictionary<string, string>
            {
                { "name", name },
                { "encrypt", options["encrypt"] },
                { "source", options["source"] },
                { "target", options["target"] }
            };

            if (options["type"].Equals("differential"))
                taskManager.AddTask(name, "save-differential", cmdOptions);
            else
                taskManager.AddTask(name, "save-mirror", cmdOptions);

            output.Display.DisplayText(Statut.SUCCESS, "Task '"+ name + "' added !");
        }
    }
}
