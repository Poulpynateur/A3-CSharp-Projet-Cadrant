using System;
using System.Collections.Generic;
using EasySave.Model.Job;


namespace EasySave.Model.Task
{
    public interface ITask
    {
        Job.Job Job { get; }

        DateTime BeginAt { get; }

        DateTime FinishAt { get; }

        Dictionary<string, string> Options { get; }

        void Execute();
    }
}
