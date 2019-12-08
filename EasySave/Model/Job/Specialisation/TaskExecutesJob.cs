using EasySave.Helpers;
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
        private IJobManager jobManager;

        public TaskExecutesJob(ITaskManager taskManager, IJobManager jobManager)
        : base("execute-task", "Execute a task, if argument -n is * execute every task.")
        {
            this.taskManager = taskManager;
            this.jobManager = jobManager;

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
        private void ExecuteTask(Task.Task task)
        {
            DateTime start = DateTime.Now;
            Output.Display.DisplayText(Statut.INFO, "Execute task '" + task.Name + "' :");
            try
            {
                string[] files = Directory.GetFiles(task.Options["source"], "*", SearchOption.AllDirectories);

                jobManager.GetJobByName(task.JobName).Execute(task.Options);
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
                Output.Display.DisplayText(Statut.WARNING, "Task '" + task.Name + "' fail : " + e.Message);
            }
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Execute one or all tasks in function of the options.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            if (options["name"].Equals("*"))
            {
                foreach (Task.Task task in taskManager.Map)
                {
                    ExecuteTask(task);
                }
            }
            else
            {
                string[] separators = { ";" };
                string[] tasksNames = options["name"].Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var task in tasksNames)
                {
                    ExecuteTask(taskManager.GetTaskByName(task));
                }
            }
        }
    }
}