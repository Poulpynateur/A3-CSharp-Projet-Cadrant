using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Input;

namespace EasySave.Model.Task
{
    public interface ITask
    {
        ICommand Command { get; }

        DateTime BeginAt { get; }

        DateTime FinishAt { get; }

        Dictionary<string, string> Options { get; }

        void Execute();
    }
}
