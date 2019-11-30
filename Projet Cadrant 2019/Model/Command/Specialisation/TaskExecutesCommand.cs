using EasySave.Helpers.Files;
using EasySave.Model.Config;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    /// <summary>
    /// Execute a task, if argument -n is * execute every task.
    /// </summary>
    class TaskExecutesCommand : BaseCommand
    {
        private ILogger logger;

        private ITaskManager taskManager;
        private ICommandManager commandManager;

        public TaskExecutesCommand(ITaskManager taskManager, ICommandManager commandManager, ILogger logger)
        : base("execute-task", "Execute a task, if argument -n is * execute every task.")
        {
            this.logger = logger;
            this.taskManager = taskManager;
            this.commandManager = commandManager;

            this.Options = new Dictionary<string, string>
            {
                { "n", ".*" }
            };
        }

        /// <summary>
        /// Execute a specific task.
        /// </summary>
        /// <param name="task">Task to execute</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private string ExecuteTask(ITask task)
        {
            DateTime start = DateTime.Now;
            string result = "";
            try
            {
                string[] files = Directory.GetFiles(task.Info.Options["source"], "*", SearchOption.AllDirectories);

                result += commandManager.GetCmdByName(task.Info.CmdName).Execute(task.Info.Options) + "\n";
                Log log = new Log();
                log.FeedLog(
                    task.Info.Name,
                    task.Info.Options["source"],
                    task.Info.Options["target"],
                    FilesManager.GetFilesSize(files),
                    DateTime.Now - start
                );

                logger.WriteLog(log);
            }
            catch (Exception e)
            {
                result += e.Message + "\n";
            }

            return result;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Execute one or all tasks in function of the options.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
        {
            string result = "";

            if (options["n"].Equals("*"))
            {
                foreach (ITask task in taskManager.Map)
                {
                    result += ExecuteTask(task);
                }
            }
            else
            {
                result += ExecuteTask(taskManager.GetTaskByName(options["n"]));
            }

            return result;
        }
    }
}