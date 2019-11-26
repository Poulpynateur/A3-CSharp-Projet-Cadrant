using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    class AddTaskCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public AddTaskCommand(ITaskManager taskManager)
        : base("add-task", "Add a task")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>
            {
                { "t", "differential|mirror" },
                { "n", ".*" },
                { "source", ".*" },
                { "target", ".*" }
            };
        }

        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            Dictionary<string, string> cmdOptions = new Dictionary<string, string>
            {
                { "source", options["source"] },
                { "target", options["target"] }
            };

            if (options["t"].Equals("differential"))
                taskManager.AddTask(options["n"], "save-differential", cmdOptions);
            else
                taskManager.AddTask(options["n"], "save-mirror", cmdOptions);

            return "Task "+ options["n"] + " added !";
        }
    }
}
