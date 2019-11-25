using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public interface ITaskManager
    {
        List<ITask> Map { get; }
        void AddTask(string taskName, Command.BaseCommand cmd);
        void RemoveTask(string name);
    }
}
