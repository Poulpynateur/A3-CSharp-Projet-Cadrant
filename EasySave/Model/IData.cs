using EasySave.Helpers;
using EasySave.Model.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Model
{
    /// <summary>
    /// Interface to access the data from the model
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// Get the interface IDisplayable
        /// </summary>
        /// <returns>The interface IDisplayable</returns>
        IDisplayable GetDisplayable();

        /// <summary>
        /// Get the tasks 
        /// </summary>
        /// <returns>List of the tasks</returns>
        List<Task.Task> GetTasks();

        /// <summary>
        /// Get the blacklisted ERP
        /// </summary>
        /// <returns>List of the blacklisted ERP</returns>
        List<string> GetErpBlacklist();

        /// <summary>
        /// Get the extensions of the files to encrypt
        /// </summary>
        /// <returns>List of the extensions of the files to encrypt</returns>
        List<string> GetEncryptExtensions();

        /// <summary>
        /// Get the extensions of the files to set priority
        /// </summary>
        /// <returns>List of the file extensions for the priority</returns>
        List<string> GetPriorityExtensions();

        /// <summary>
        /// Get the maximum size of the files authorized to transfer
        /// </summary>
        /// <returns>The maximum size of a file authorized to transfer</returns>
        long GetMaxFileSize();

        /// <summary>
        /// Get the Lang object
        /// </summary>
        /// <returns>Lang object</returns>
        Lang GetLang();
    }
}
