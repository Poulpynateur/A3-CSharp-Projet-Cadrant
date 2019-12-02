using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    /// <summary>
    /// Interface to access command manager from commands.
    /// For exemple : <see cref="Specialisation.HelpCommand"/>
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Map of the commands.
        /// </summary>
        List<BaseCommand> Map { get; }
        /// <summary>
        /// Get a command by its name.
        /// </summary>
        /// <param name="name">Name of the target</param>
        /// <returns>The command or null</returns>
        BaseCommand GetCmdByName(string name);
    }
}
