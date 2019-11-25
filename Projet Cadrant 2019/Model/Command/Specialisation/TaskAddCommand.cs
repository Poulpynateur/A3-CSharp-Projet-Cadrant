using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    class TaskAddCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public TaskAddCommand(ITaskManager taskManager) : base(Type.Standard, "add-task", "Add a task.")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>
            {
                { "name", ".*" },
                { "type", ".*" },
                { "source", ".*" },
                { "target", ".*" },
            };
        }

        public override void Execute(Dictionary<string, string> options)
        {
            this.checkOptionsValidity(options);
            updateCmdState(State.Processing, "Creating task ...");

            taskManager.AddTask("name", new TestCommand());

            updateCmdState(State.Success, "");
        }
    }
}
