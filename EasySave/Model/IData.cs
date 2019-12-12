using EasySave.Helpers;
using EasySave.Model.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Model
{
    public interface IData
    {
        IDisplayable GetDisplayable();

        List<Task.Task> GetTasks();
        List<string> GetErpBlacklist();
        List<string> GetEncryptExtensions();
        List<string> GetPriorityExtensions();
        long GetMaxFileSize();
        Lang GetLang();
    }
}
