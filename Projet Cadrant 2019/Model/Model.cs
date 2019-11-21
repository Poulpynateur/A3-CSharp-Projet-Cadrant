using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;
using EasySave.Model.Task;

namespace EasySave.Model
{
    class Model : IModel
    {
        public ITaskManager TaskManager => throw new NotImplementedException();

        public ICommandManager CommandManager => throw new NotImplementedException();


        private ConfigManager Config;
    }
}
