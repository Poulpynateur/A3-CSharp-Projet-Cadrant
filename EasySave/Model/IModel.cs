using EasySave.Helpers;
using EasySave.Model.Job;
using System;
using System.Collections.Generic;

namespace EasySave.Model
{
    /// <summary>
    /// Interface to access model.
    /// </summary>
    public interface IModel 
    {
        public IDisplayable GetDisplayable();
        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Name of the target</param>
        /// <returns>A command or null</returns>
        BaseJob GetJobByName(string name);
        IEnumerable<Tuple<string, string>> GetTasksNames();

        List<string> GetErpBlacklist();
        void SetErpBlacklist(List<string> erp);
        List<string> GetEncryptFormat();
        void SetEncryptFormat(List<string> format);
    }
}
