using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job
{
    public interface IJobManager
    {
        event Job.JobStateHandler JobState;

        List<Job> Map { get; }

        bool isJobName(string name);
        void ExecuteJob(string name, Dictionary<string, string> options);
    }
}
