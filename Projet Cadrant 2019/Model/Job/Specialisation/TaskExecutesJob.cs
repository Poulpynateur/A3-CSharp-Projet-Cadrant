using EasySave.Helpers.Files;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Execute a task, if argument -n is * execute every task.
    /// </summary>
    class TaskExecutesJob : BaseJob
    {
        private ITaskManager taskManager;
        private IJobManager commandManager;

        public TaskExecutesJob(ITaskManager taskManager, IJobManager commandManager)
        : base("execute-task", "Execute a task, if argument -n is * execute every task.")
        {
            this.taskManager = taskManager;
            this.commandManager = commandManager;

            this.Options = new List<Option>
            {
                new Option("name", "Name of the task(s) to execute(s) (* for all)", ".*")
            };
        }

        /// <summary>
        /// Execute a specific task.
        /// </summary>
        /// <param name="task">Task to execute</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private string ExecuteTask(Task.Task task)
        {
            DateTime start = DateTime.Now;
            string result = "";
            try
            {
                string[] files = Directory.GetFiles(task.Options["source"], "*", SearchOption.AllDirectories);

                result += commandManager.GetJobByName(task.CmdName).Execute(task.Options) + "\n";
                Log log = new Log();
                log.FeedLog(
                    task.Name,
                    task.Options["source"],
                    task.Options["target"],
                    FilesHelper.GetFilesSize(files),
                    DateTime.Now - start
                );

                Output.Logger.WriteLog(log);
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

            if (options["name"].Equals("*"))
            {
                foreach (Task.Task task in taskManager.Map)
                {
                    result += ExecuteTask(task);
                }
            }
            else
            {
                result += ExecuteTask(taskManager.GetTaskByName(options["name"]));
            }

            return result;
        }
    }
}