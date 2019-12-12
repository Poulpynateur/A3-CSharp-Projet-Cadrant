using EasySave.Model.Job;
using EasySave.Model.Management;
using System;
using System.Collections.Generic;

namespace EasySave.Model
{
    /// <summary>
    /// Interface to access model.
    /// </summary>
    public interface IModel : IData
    {
        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Name of the target</param>
        /// <returns>A command or null</returns>
        BaseJob GetJobByName(string name);

        Threads GetThreads();

        void SetErpBlacklist(List<string> erp);
        void SetEncryptExtensions(List<string> format);
        void SetPriorityExtensions(List<string> priority);
        void SetMaxFileSize(long bytes);
    }
}
