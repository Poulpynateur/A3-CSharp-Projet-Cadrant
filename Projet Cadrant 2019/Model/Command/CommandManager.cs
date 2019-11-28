using EasySave.Model.Command.Specialisation;
using EasySave.Model.Config;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    /// <summary>
    /// Singleton class. Manage the differents commands and instanciate then.
    /// </summary>
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

        /// <summary>
        /// Load all the commands into a list.
        /// </summary>
        /// <param name="taskManager">Task manager to pass to commands that interact with tasks.</param>
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

        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Command name</param>
        /// <returns>The command if found, else return null</returns>
        public BaseCommand getCmdByName(string name)
        {
            return Map.Find(command => command.Name == name);
        }
    }
}
