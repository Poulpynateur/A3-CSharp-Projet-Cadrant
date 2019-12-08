using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.View
{
    public enum QuickSaveAction
    {
        MIRROR,
        DIFFERENTIAL
    }
    public enum TaskAction
    {
        REMOVE,
        EXECUTE,
        ADD
    }

    public delegate void QuickSaveEventHandler(QuickSaveAction action, Dictionary<string, string> options);
    public delegate void TaskEventHandler(TaskAction action, Dictionary<string, string> options);

    public interface IWindow
    {
        event QuickSaveEventHandler QuickSaveEvent;
        event TaskEventHandler TaskEvent;

        void Show();
        void DisplayText(Statut statut, string text);
        void RefreshTaskList();
    }
}
