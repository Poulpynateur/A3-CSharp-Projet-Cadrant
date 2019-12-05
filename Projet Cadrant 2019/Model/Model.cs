using EasySave.Helpers;
using EasySave.Model.Job;
using EasySave.Model.Output;
using EasySave.Model.Task;
using System.IO;

namespace EasySave.Model
{
    /// <summary>
    /// Define commands and how to interact with configuration.
    /// </summary>
    public class Model : IModel
    {
        private Output.Output output;

        private JobManager jobs;
        private TaskManager tasks;

        public Model()
        {
            this.output = new Output.Output();

            this.tasks = TaskManager.Instance;
            tasks.LoadTasks(output.Config);

            this.jobs = JobManager.Instance;
            this.jobs.SetOutput(output);
            jobs.LoadJobs(tasks);
        }

        /// <summary>
        /// Get a command by name, use <see cref="JobManager.GetJobByName(string)"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Return a <see cref="BaseCommand"/> or null if not found</returns>
        public BaseJob GetJobByName(string name)
        {
            return jobs.GetJobByName(name);
        }

        public IDisplayable GetDisplayable()
        {
            return output.Display;
        }
    }
}
