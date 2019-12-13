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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taskManager">ITaskManager object</param>
        /// <param name="jobManager">IJobManager</param>
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
            management.Display.DisplayText(Statut.INFO, management.Lang.Translate("Execute task : ") + task.Name);
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

                management.Logger.WriteLog(log);
            }
            catch (Exception e)
            {
                management.Display.DisplayText(Statut.WARNING, management.Lang.Translate("Task '")  + task.Name + management.Lang.Translate("' fail : ") + e.Message);
            }
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Execute one or all tasks in function of the options.
        /// </summary>
        /// <param name="options">Dictionary of options needed to execute the job</param>
        public override void Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            string[] separators = { ";" };
            string[] tasksNames = options["name"].Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Execute the job for each task
            foreach (var task in tasksNames)
            {
                 ExecuteTask(taskManager.GetTaskByName(task));
            }
            
        }
    }
}