using System;
using System.Collections.Generic;
using EasySave.Model.Command;


namespace EasySave.Model.Task
{
    public interface ITask
    {
        Command.Command Command { get; }

        DateTime BeginAt { get; }

        DateTime FinishAt { get; }

        Dictionary<string, string> Options { get; }

        void Execute();
    }
}
