using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    class ShowTaskCommand : BaseCommand
    {
        private ITaskManager taskManager;

        public ShowTaskCommand(ITaskManager taskManager)
        : base("show-tasks", "Show the list of task.")
        {
            this.taskManager = taskManager;

            this.Options = new Dictionary<string, string>();
        }

        public override string Execute(Dictionary<string, string> options)
        {
            string str = "";

            foreach(ITask task in taskManager.Map)
            {
                str += task.Name + " : command [" + task.CmdName + "] created at " + task.CreatedAt + "\n";
            }

            return str;
        }
    }
}