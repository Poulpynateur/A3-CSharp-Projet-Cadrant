using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Information of a task.
    /// </summary>
    public class TaskInfo
    {
        /// <summary>
        /// Name of the task.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Date of creation of the task.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Name of the command linked to this task.
        /// </summary>
        public string CmdName { get; set; }
        /// <summary>
        /// List of options of the linked command.
        /// </summary>
        public Dictionary<string, string> Options { get; set; }
    }
}
