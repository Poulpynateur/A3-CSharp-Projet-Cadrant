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
        List<BaseCommand> Map { get; }
        BaseCommand getCmdByName(string name);
    }
}
