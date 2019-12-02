using EasySave.Model.Command;
using System.Collections.Generic;

namespace EasySave.Model
{
    /// <summary>
    /// Interface to access model.
    /// </summary>
    public interface IModel 
    {
        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Name of the target</param>
        /// <returns>A command or null</returns>
        BaseCommand getCmdByName(string name);
    }
}
