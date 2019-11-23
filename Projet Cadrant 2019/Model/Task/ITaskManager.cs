using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Job;

namespace EasySave.Model.Task
{
    public interface ITaskManager
    {
        void AddTask(string name, Job.Job Job);

        void RemoveTask(string name);
    }
}
