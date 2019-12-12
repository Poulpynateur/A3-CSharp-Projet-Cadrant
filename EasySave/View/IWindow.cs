using EasySave.Helpers;
using EasySave.Model;
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
        ADD,
        STOP,

        PAUSE,
        RESTART
    }

    public delegate void QuickSaveEventHandler(QuickSaveAction action, Dictionary<string, string> options);
    public delegate void TaskEventHandler(TaskAction action, Dictionary<string, string> options);
    public delegate void ParamEventHandler(Dictionary<string, List<string>> parameters);

    /// <summary>
    /// Interface of the main window
    /// </summary>
    public interface IWindow
    {
        event QuickSaveEventHandler QuickSaveEvent;
        event TaskEventHandler TaskEvent;
        event ParamEventHandler ParamEvent;

        void Show();
        void DisplayText(Statut statut, string text);
        void DisplayProgress(string name, Progress progress);
        void RefreshControlText();
        void RefreshTaskList();
    }
}
