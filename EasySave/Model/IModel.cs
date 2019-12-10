using EasySave.Model.Job;
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
        IEnumerable<Tuple<string, string>> GetTasksNames();

        void SetErpBlacklist(List<string> erp);
        void SetEncryptFormat(List<string> format);
    }
}
