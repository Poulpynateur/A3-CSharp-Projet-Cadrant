using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public class Task : ITask
    {
        public DateTime BeginAt { get; private set; }

        public DateTime FinishAt { get; private set; }

        public Dictionary<string, string> Options { get; private set; }

        public Command.Command Command { get; private set; }

        public Task(Command.Command command)
        {
            this.Command = command;
        }

        public void Execute()
        {
            Command.Execute(Options);
        }
    }
}
