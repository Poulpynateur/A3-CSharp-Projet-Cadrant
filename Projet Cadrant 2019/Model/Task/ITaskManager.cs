using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EasySave.Model.Task
{
    public interface ITaskManager
    {
        void AddTask(string name, ICommand Command);

        void RemoveTask(string name);
    }
}
