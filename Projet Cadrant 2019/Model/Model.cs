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
        private CommandManager commands;
        private TaskManager tasks;
        private ConfigManager config;

        public Model()
        {
            this.tasks = TaskManager.Instance;
            this.commands = CommandManager.Instance;

            this.config = ConfigManager.Instance;
        }

        public ICommand getCmdByName(string name)
        {
            return commands.getCmdByName(name);
        }
    }
}
