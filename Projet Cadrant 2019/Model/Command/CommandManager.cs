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
        /// <summary>
        /// Map of the commands.
        /// </summary>
        public List<BaseCommand> Map { get; }

        private static readonly Lazy<CommandManager> lazy = new Lazy<CommandManager>(() => new CommandManager());
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static CommandManager Instance { get { return lazy.Value; } }

        private CommandManager()
        {
            Map = new List<BaseCommand>();
        }

        /// <summary>
        /// Load all the commands into a list.
        /// </summary>
        /// <param name="taskManager">Task manager to pass to commands that interact with tasks</param>
        /// <param name="logger">Used to log informations</param>
        public void LoadCommands(ITaskManager taskManager, ILogger logger)
        {
            Map.Add(new HelpCommand(this));

            //Task management
            Map.Add(new TaskListCommand(taskManager));
            Map.Add(new TaskRemoveCommand(taskManager));
            Map.Add(new TaskAddCommand(taskManager));
            Map.Add(new TaskExecutesCommand(taskManager, this, logger));

            //Save
            Map.Add(new SaveMirrorCommand(logger));
            Map.Add(new SaveDifferentialCommand(logger));
        }

        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Command name</param>
        /// <returns>The command if found, else return null</returns>
        public BaseCommand GetCmdByName(string name)
        {
            return Map.Find(command => command.Name == name);
        }
    }
}
