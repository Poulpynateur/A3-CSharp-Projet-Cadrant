using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job
{
    /// <summary>
    /// Interface to access command manager from commands.
    /// For exemple : <see cref="Specialisation.HelpCommand"/>
    /// </summary>
    public interface IJobManager
    {
        /// <summary>
        /// Map of the commands.
        /// </summary>
        List<BaseJob> Map { get; }

        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Name of the target</param>
        /// <returns>The command or null</returns>
        BaseJob GetJobByName(string name);
    }
}
