using System;
using System.Collections.Generic;
using EasySave.Model.Command;


namespace EasySave.Model.Task
{
    public interface ITask
    {
        string Name { get;  }

        DateTime CreatedAt { get; }

        string CmdName { get;  }
        Dictionary<string, string> Options { get; }
    }
}
