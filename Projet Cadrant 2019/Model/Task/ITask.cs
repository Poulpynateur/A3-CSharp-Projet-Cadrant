using System;
using System.Collections.Generic;
using EasySave.Model.Command;


namespace EasySave.Model.Task
{
    /// <summary>
    /// Interface to access task.
    /// </summary>
    public interface ITask
    {
        TaskInfo Info { get; set; }
    }
}
