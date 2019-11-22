using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;
using EasySave.Model.Task;

namespace EasySave.Model
{
    public class Model : IModel
    {
        public ITaskManager TaskManager { get; private set; }

        public ICommandManager CommandManager { get; private set; }

        private ConfigManager Config;

        public Model()
        {
            this.TaskManager = new TaskManager();
            this.CommandManager = new CommandManager();

            this.Config = ConfigManager.Instance;
        }
    }
}
