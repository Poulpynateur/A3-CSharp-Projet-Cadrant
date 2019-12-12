using EasySave.Helpers;
using EasySave.Model.Job;
using EasySave.Model.Management;
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
        private Management.Management management;
        private JobManager jobs;
        private TaskManager tasks;

        public Model()
        {
            this.management = Management.Management.Instance;

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

        public List<Task.Task> GetTasks()
        {
            return tasks.Map;
        }

        public IDisplayable GetDisplayable()
        {
            return management.Display;
        }

        public void SetErpBlacklist(List<string> erp)
        {
            management.ErpBlacklist = erp;
            management.Config.SaveErpBlackList(erp);
        }
        public List<string> GetErpBlacklist()
        {
            return management.ErpBlacklist;
        }
        public void SetEncryptExtensions(List<string> format)
        {
            management.Encrypt.CryptFormat = format;
            management.Config.SaveEncryptFormat(format);
        }
        public List<string> GetEncryptExtensions()
        {
            return management.Encrypt.CryptFormat;
        }

        public Lang GetLang()
        {
            return management.Lang;
        }

        public Threads GetThreads()
        {
            return management.Threads;
        }

        public void SetPriorityExtensions(List<string> priority)
        {
            management.PriorityExtension = priority;
            management.Config.SavePriorityExtension(priority);
        }
        public List<string> GetPriorityExtensions()
        {
            return management.PriorityExtension;
        }
    }
}
