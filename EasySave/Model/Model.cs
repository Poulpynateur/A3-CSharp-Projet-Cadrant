using EasySave.Helpers;
using EasySave.Model.Job;
using EasySave.Model.Output;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            this.output = Output.Output.Instance;

            this.tasks = new TaskManager();
            this.jobs = new JobManager(tasks);
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

        public IEnumerable<Tuple<string, string>> GetTasksNames()
        {
            return tasks.Map.Select(task => new Tuple<string, string>(task.Name, "Created at " + task.CreatedAt.ToString()));
        }

        public IDisplayable GetDisplayable()
        {
            return output.Display;
        }

        public void SetErpBlacklist(List<string> erp)
        {
            output.ErpBlacklist = erp;
            output.Config.SaveErpBlackList(erp);
        }
        public List<string> GetErpBlacklist()
        {
            return output.ErpBlacklist;
        }
        public void SetEncryptFormat(List<string> format)
        {
            output.Encrypt.CryptFormat = format;
            output.Config.SaveEncryptFormat(format);
        }
        public List<string> GetEncryptFormat()
        {
            return output.Encrypt.CryptFormat;
        }
    }
}
