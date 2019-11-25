using System;
using System.Collections.Generic;
using EasySave.Model.Command;


namespace EasySave.Model.Task
{
    public interface ITask
    {
        string Name { get;  }

        Command.BaseCommand Job { get; }

        DateTime BeginAt { get; }

        DateTime FinishAt { get; }

        Dictionary<string, string> Options { get; }

        void Execute();
    }
}
