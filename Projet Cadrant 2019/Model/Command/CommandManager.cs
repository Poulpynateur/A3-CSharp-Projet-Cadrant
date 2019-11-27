using EasySave.Model.Command.Specialisation;
using EasySave.Model.Config;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public sealed class CommandManager : ICommandManager
    {
        public ILogger Logger { private get; set; }
        public List<BaseCommand> Map { get; }

        private static readonly Lazy<CommandManager> lazy = new Lazy<CommandManager>(() => new CommandManager());
        public static CommandManager Instance { get { return lazy.Value; } }

        private CommandManager()
        {
            Map = new List<BaseCommand>();
        }

        public void LoadCommands(ITaskManager taskManager)
        {
            Map.Add(new HelpCommand(this));

            //Task management
            Map.Add(new TaskListCommand(taskManager));
            Map.Add(new TaskRemoveCommand(taskManager));
            Map.Add(new TaskAddCommand(taskManager));
            Map.Add(new TaskExecutesCommand(taskManager, this, Logger));

            //Save
            Map.Add(new SaveMirrorCommand(Logger));
            Map.Add(new SaveDifferentialCommand(Logger));
        }

        public BaseCommand getCmdByName(string name)
        {
            return Map.Find(command => command.Name == name);
        }
    }
}
