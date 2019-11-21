using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EasySave.Model.Task
{
    class Task : ITask
    {
        public DateTime BeginAt => throw new NotImplementedException();

        public DateTime FinishAt => throw new NotImplementedException();

        public Dictionary<string, string> Options => throw new NotImplementedException();

        public ICommand Command => throw new NotImplementedException();

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
