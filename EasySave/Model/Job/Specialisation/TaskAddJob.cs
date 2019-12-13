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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taskManager">ITaskManager object</param>
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

        /// <summary>
        /// Get unique name for task
        /// </summary>
        /// <param name="wantedName">Wanted name</param>
        /// <returns></returns>
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
        /// <param name="options">Dictionary of options needed to execute the job</param>
        public override void Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            // Defines the new dictionary used during the adding of the task
            string name = GetUniqueName(options["name"]);
            Dictionary<string, string> cmdOptions = new Dictionary<string, string>
            {
                { "name", name },
                { "encrypt", options["encrypt"] },
                { "source", options["source"] },
                { "target", options["target"] }
            };

            // Add task depending on the type of save
            if (options["type"].Equals("differential"))
                taskManager.AddTask(name, "save-differential", cmdOptions);
            else
                taskManager.AddTask(name, "save-mirror", cmdOptions);

            management.Display.DisplayText(Statut.SUCCESS, name + " " + management.Lang.Translate("Added"));
        }
    }
}
