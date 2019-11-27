using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Task
{
    public class TaskInfo
    {
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CmdName { get; set; }
        public Dictionary<string, string> Options { get; set; }
    }
}
