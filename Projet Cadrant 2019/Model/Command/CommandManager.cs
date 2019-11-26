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
        public IProgress ProgressSaver { private get; set; }
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
            Map.Add(new TestCommand());

            //Task management
            Map.Add(new AddTaskCommand(taskManager));
            Map.Add(new ShowTaskCommand(taskManager));
        }

        public BaseCommand getCmdByName(string name)
        {
            return Map.Find(command => command.Name == name);
        }
    }
}
