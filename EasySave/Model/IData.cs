using EasySave.Helpers;
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

        IEnumerable<Tuple<string, string>> GetTasksNames();
        List<string> GetErpBlacklist();
        List<string> GetEncryptFormat();
    }
}
