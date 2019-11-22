using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public interface ICommandManager
    {

        List<Command> Commands { get; }

        void ExecuteCommand(string Name, Dictionary<string, string> Options);
    }
}
