using EasySave.Model.Management.DataFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySave.Model.Management
{
    public class Threads
    {
        public Dictionary<string, ThreadInfo> Map { get; }

        public Threads()
        {
            Map = new Dictionary<string, ThreadInfo>();
        }

        public bool AddThread(string name, Thread thread)
        {
            if(!Map.ContainsKey(name))
            {
                Map.Add(name, new ThreadInfo(thread, new ManualResetEvent(true)));
                return true;
            }
            return false;
        }
    }
}
