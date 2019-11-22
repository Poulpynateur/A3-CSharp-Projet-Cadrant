using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public abstract class Command
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, string> Options { get; protected set; }

        public Command(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public abstract void Execute(Dictionary<string, string> Options);

    }
}
