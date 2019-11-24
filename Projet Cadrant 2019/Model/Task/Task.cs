using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public class Task : ITask
    {
        public string Name { get; }

        public DateTime BeginAt { get; }
        public DateTime FinishAt { get; }
        public Dictionary<string, string> Options { get; }
        public Command.BaseCommand Job { get; }

        public Task(string name, Command.BaseCommand job)
        {
            this.Name = name;
            this.Job = job;
        }

        public void Execute()
        {
            Job.Execute(Options);
        }
    }
}
