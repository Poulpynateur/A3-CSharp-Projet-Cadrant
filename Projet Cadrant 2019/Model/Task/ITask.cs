using System;
using System.Collections.Generic;
using EasySave.Model.Command;


namespace EasySave.Model.Task
{
    /// <summary>
    /// Interface to access task.
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Informations of a task.
        /// </summary>
        TaskInfo Info { get; set; }
    }
}
