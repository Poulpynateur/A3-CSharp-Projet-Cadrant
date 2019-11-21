using EasySave.Model.Command;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model
{
    public interface IModel 
    {
        public ITaskManager TaskManager {get; }
        public ICommandManager CommandManager { get; }

    }
}
