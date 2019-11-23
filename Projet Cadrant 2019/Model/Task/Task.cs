using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Job;

namespace EasySave.Model.Task
{
    public class Task : ITask
    {
        public DateTime BeginAt { get; private set; }

        public DateTime FinishAt { get; private set; }

        public Dictionary<string, string> Options { get; private set; }

        public Job.Job Job { get; private set; }

        public Task(Job.Job job)
        {
            this.Job = job;
        }

        public void Execute()
        {
            Job.Execute(Options);
        }
    }
}
