using EasySave.Model.Job;
using EasySave.Model.Task;

namespace EasySave.Model
{
    public interface IModel 
    {
        public ITaskManager Tasks {get; }
        public IJobManager Jobs { get; }
    }
}
