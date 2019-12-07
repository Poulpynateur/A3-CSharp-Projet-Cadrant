using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Task are entities that can be save and used to launch commands later. For now this class is merely useless, but let's thinks of the futur !
    /// </summary>
    public class Task
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
        public string JobName { get; set; }

        /// <summary>
        /// List of options of the linked command.
        /// </summary>
        public Dictionary<string, string> Options { get; set; }
    }
}
