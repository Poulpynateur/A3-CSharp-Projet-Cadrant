using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Task are entities that can be save and used to launch commands later. For now this class is merely useless, but let's thinks of the futur !
    /// </summary>
    public class Task : ITask
    {
        /// <summary>
        /// Informations of the task.
        /// </summary>
        public TaskInfo Info { get; set; }

        /// <summary>
        /// Task constructor.
        /// </summary>
        /// <param name="info">Information of the task</param>
        public Task(TaskInfo info)
        {
            this.Info = info;
        }
    }
}
