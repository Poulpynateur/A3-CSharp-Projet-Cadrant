using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Task are entities that can be save and used to launch commands later.
    /// </summary>
    public class Task : ITask
    {
        private ILogger logger;

        public TaskInfo Info { get; set; }

        public Task(ILogger logger, TaskInfo info)
        {
            this.logger = logger;
            this.Info = info;
        }
    }
}
