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
        /// <summary>
        /// Management object
        /// </summary>
        private Management.Management management;

        /// <summary>
        /// JobManager object
        /// </summary>
        private JobManager jobs;

        /// <summary>
        /// TaskManager object
        /// </summary>
        private TaskManager tasks;

        /// <summary>
        /// Constructor
        /// </summary>
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

        /// <summary>
        /// Get the tasks
        /// </summary>
        /// <returns>List of the tasks</returns>
        public List<Task.Task> GetTasks()
        {
            return tasks.Map;
        }

        /// <summary>
        /// Get the view of the management
        /// </summary>
        /// <returns>Interface IDisplayable</returns>
        public IDisplayable GetDisplayable()
        {
            return management.Display;
        }

        /// <summary>
        /// Set the blacklisted ERP
        /// </summary>
        /// <param name="erp">List of the ERP</param>
        public void SetErpBlacklist(List<string> erp)
        {
            management.ErpBlacklist = erp;
            management.Config.SaveErpBlackList(erp);
        }

        /// <summary>
        /// Get the blacklisted ERP
        /// </summary>
        /// <returns>List of the blacklisted ERP</returns>
        public List<string> GetErpBlacklist()
        {
            return management.ErpBlacklist;
        }

        /// <summary>
        /// Set the extensions of the files to encrypt
        /// </summary>
        /// <param name="format">List of the extensions of the files to encrypt</param>
        public void SetEncryptExtensions(List<string> format)
        {
            management.Encrypt.CryptFormat = format;
            management.Config.SaveEncryptFormat(format);
        }

        /// <summary>
        /// Get the extensions of the files to encrypt
        /// </summary>
        /// <returns>List of the extensions of the files to encrypt</returns>
        public List<string> GetEncryptExtensions()
        {
            return management.Encrypt.CryptFormat;
        }

        /// <summary>
        /// Get the Lang 
        /// </summary>
        /// <returns>Lang object</returns>
        public Lang GetLang()
        {
            return management.Lang;
        }

        /// <summary>
        /// Get the threads
        /// </summary>
        /// <returns>Threads object</returns>
        public Threads GetThreads()
        {
            return management.Threads;
        }

        /// <summary>
        /// Set the extensions of the files that have priority
        /// </summary>
        /// <param name="priority">List of the extensions of the files that have priority</param>
        public void SetPriorityExtensions(List<string> priority)
        {
            management.PriorityExtension = priority;
            management.Config.SavePriorityExtension(priority);
        }

        /// <summary>
        /// Get the extensions of the files that have priority
        /// </summary>
        /// <returns>List of the extensions of the files that have priority</returns>
        public List<string> GetPriorityExtensions()
        {
            return management.PriorityExtension;
        }

        /// <summary>
        /// Set the maximum size of the files to be transferred
        /// </summary>
        /// <param name="bytes">Maximum size of the files to be transferred</param>
        public void SetMaxFileSize(long bytes)
        {
            management.MaxBytesFileSize = bytes;
        }

        /// <summary>
        /// Get the maximum file size authorized to be transferred
        /// </summary>
        /// <returns>Maximum file size authorized to be transferred</returns>
        public long GetMaxFileSize()
        {
            return management.MaxBytesFileSize;
        }

        /// <summary>
        /// Dispose the resources used by the progress socket
        /// </summary>
        public void Close()
        {
            management.Logger.Close();
        }
    }
}
