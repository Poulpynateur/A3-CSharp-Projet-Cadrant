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

        public string CmdName { get; }
        public Dictionary<string, string> Options { get; }

        public Task(string name, string cmdName)
        {
            this.Name = name;
            this.CmdName = cmdName;
        }
    }
}
