using EasySave.Helpers;
using EasySave.Model.Job;

namespace EasySave.Model
{
    /// <summary>
    /// Interface to access model.
    /// </summary>
    public interface IModel 
    {
        public IDisplayable GetDisplayable();
        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Name of the target</param>
        /// <returns>A command or null</returns>
        BaseJob GetJobByName(string name);
    }
}
