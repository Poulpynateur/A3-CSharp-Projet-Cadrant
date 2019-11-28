using EasySave.Model.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Interface to access task manager.
    /// </summary>
    public interface ITaskManager
    {
        List<ITask> Map { get; }

        ITask GetTaskByName(string name);

        void AddTask(string taskName, string cmdName, Dictionary<string, string> options);
        int RemoveTask(string taskName);
    }
}
