using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public interface ICommandManager
    {
        event ICommand.CmdStateHandler CmdState;

        List<ICommand> Map { get; }

        bool isCmdName(string name);
        ICommand getCmdByName(string name);
    }
}
