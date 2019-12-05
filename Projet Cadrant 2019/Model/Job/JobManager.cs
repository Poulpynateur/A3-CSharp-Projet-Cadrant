using EasySave.Model.Job.Specialisation;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job
{
    /// <summary>
    /// Singleton class. Manage the differents commands and instanciate then.
    /// </summary>
    public sealed class JobManager : IJobManager
    {
        /// <summary>
        /// Map of the commands.
        /// </summary>
        public List<BaseJob> Map { get; }

        private static readonly Lazy<JobManager> lazy = new Lazy<JobManager>(() => new JobManager());
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static JobManager Instance { get { return lazy.Value; } }

        private JobManager()
        {
            Map = new List<BaseJob>();
        }

        public void SetOutput(Output.Output output)
        {
            BaseJob.Output = output;
        }
        
        /// <summary>
        /// Load all the commands into a list.
        /// </summary>
        /// <param name="taskManager">Task manager to pass to commands that interact with tasks</param>
        /// <param name="logger">Used to log informations</param>
        public void LoadJobs(ITaskManager taskManager)
        {
            Map.Add(new HelpJob(this));

            //Task management
            Map.Add(new TaskListJob(taskManager));
            Map.Add(new TaskRemoveJob(taskManager));
            Map.Add(new TaskAddJob(taskManager));
            Map.Add(new TaskExecutesJob(taskManager, this));

            //Save
            Map.Add(new SaveMirrorJob());
            Map.Add(new SaveDifferentialJob());
        }

        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Command name</param>
        /// <returns>The command if found, else return null</returns>
        public BaseJob GetJobByName(string name)
        {
            return Map.Find(command => command.Info.Name == name);
        }
    }
}
