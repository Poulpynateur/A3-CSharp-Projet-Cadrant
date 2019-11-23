using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Job;
using EasySave.Model.Config;
using EasySave.Model.Task;

namespace EasySave.Model
{
    public class Model : IModel
    {
        public ITaskManager Tasks { get; private set; }

        public IJobManager Jobs { get; private set; }

        private ConfigManager config;

        public Model()
        {
            this.Tasks = new TaskManager();
            this.Jobs = new JobManager();

            this.config = ConfigManager.Instance;
        }
    }
}
