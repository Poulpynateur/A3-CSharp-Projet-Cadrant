using EasySave.Model.Command;
using EasySave.Model.Config;
using EasySave.Model.Task;

namespace EasySave.Model
{
    /// <summary>
    /// Define commands and how to interact with configuration.
    /// </summary>
    public class Model : IModel
    {
        private CommandManager commands;
        private TaskManager tasks;
        private ConfigManager config;

        public Model()
        {
            this.config = ConfigManager.Instance;

            this.tasks = TaskManager.Instance;
            tasks.tasksFromInfo(config.LoadTasksInfo());
            tasks.Config = config;

            this.commands = CommandManager.Instance;
            commands.Logger = config;
            commands.LoadCommands(tasks);
        }

        /// <summary>
        /// Get a command by name, use <see cref="CommandManager.getCmdByName(string)"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Return a <see cref="BaseCommand">BaseCommand</see></returns>
        public BaseCommand getCmdByName(string name)
        {
            return commands.getCmdByName(name);
        }
    }
}
