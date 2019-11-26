using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Task
{
    public interface ITaskManager
    {
        List<ITask> Map { get; }

        void AddTask(string taskName, string cmdName, Dictionary<string, string> options);
        void RemoveTask(string taskName);
    }
}
