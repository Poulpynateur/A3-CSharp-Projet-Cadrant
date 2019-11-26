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
            this.config = ConfigManager.Instance;

            this.tasks = TaskManager.Instance;
            tasks.Map = config.LoadTasks();
            tasks.Logger = config;

            this.commands = CommandManager.Instance;
            commands.ProgressSaver = config;
            commands.LoadCommands(tasks);
        }

        public BaseCommand getCmdByName(string name)
        {
            return commands.getCmdByName(name);
        }
    }
}
