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
        public ICommandManager Jobs { get; private set; }

        private ITaskManager task;
        private ConfigManager config;

        public Model()
        {
            this.task = new TaskManager();
            this.Jobs = new CommandManager(task);

            this.config = ConfigManager.Instance;
        }
    }
}
