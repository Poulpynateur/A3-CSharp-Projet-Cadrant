using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.View
{
    /// <summary>
    /// Enum of different save types (either mirror or differential)
    /// </summary>
    public enum QuickSaveAction
    {
        MIRROR,
        DIFFERENTIAL
    }

    /// <summary>
    /// Enum of possible actions on tasks (add, remove or execute)
    /// </summary>
    public enum TaskAction
    {
        REMOVE,
        EXECUTE,
        ADD
    }

    public delegate void QuickSaveEventHandler(QuickSaveAction action, Dictionary<string, string> options);
    public delegate void TaskEventHandler(TaskAction action, Dictionary<string, string> options);

    /// <summary>
    /// Interface of the main window
    /// </summary>
    public interface IWindow
    {
        event QuickSaveEventHandler QuickSaveEvent;
        event TaskEventHandler TaskEvent;

        void Show();
        void DisplayText(Statut statut, string text);
        void RefreshTaskList();
    }
}
