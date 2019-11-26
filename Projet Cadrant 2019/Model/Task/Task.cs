using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;

namespace EasySave.Model.Task
{
    public class Task : ITask
    {
        private ILogger logger;

        public string Name { get; }

        public DateTime CreatedAt { get; }
        public string CmdName { get; }
        public Dictionary<string, string> Options { get; }

        public Task(ILogger logger, string name, string cmdName, Dictionary<string, string> options)
        {
            this.logger = logger;

            this.CreatedAt = DateTime.Now;

            this.Name = name;
            this.CmdName = cmdName;
            this.Options = options;
        }
    }
}
