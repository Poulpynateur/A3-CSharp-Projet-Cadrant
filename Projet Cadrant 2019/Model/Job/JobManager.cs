using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job
{
    public class JobManager : IJobManager
    {
        public List<Job> Map { get; }

        //Bubble Job event for controller and config
        public event Job.JobStateHandler JobState
        {
            add { Job.JobState += value; }
            remove { Job.JobState -= value; }
        }

        public JobManager()
        {
            Map = new List<Job>()
            {
                new TestJob()
            };
        }

        public void ExecuteJob(string name, Dictionary<string, string> options)
        {
            Job command = Map.Find(command => command.Name == name);
            command.Execute(options);
        }

        public bool isJobName(string name)
        {
            Job command = Map.Find(command => command.Name == name);
            return (command != null) ? true : false;
        }
    }
}
