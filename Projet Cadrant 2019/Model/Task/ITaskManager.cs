using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public interface ITaskManager
    {
        void AddTask(string name, Command.Command Command);

        void RemoveTask(string name);
    }
}
