using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Controller
{
    public struct ParsedCommand
    {
        public string Name { get; }
        public Dictionary<string, string> Options { get; }

        public ParsedCommand(string name, Dictionary<string, string> options)
        {
            this.Name = name;
            this.Options = options;
        }
    }
}
