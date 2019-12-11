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

        public JobManager(ITaskManager taskManager)
        {
            this.Map = new List<BaseJob>();

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
            return Map.Find(job => job.Info.Name == name);
        }
    }
}
