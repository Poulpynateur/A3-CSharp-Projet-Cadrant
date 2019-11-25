using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public enum State { Error, Warning, Processing, Success };

    // Command with the config type just verify the syntax of a command,
    // the controller check his state to know the results
    public enum Type { Config, Standard }

    public interface ICommand
    {
        delegate void CmdStateHandler(State state, string input);

        Type Type { get; }
        State State { get; }

        string Name { get; }
        string Description { get; }
        Dictionary<string, string> Options { get; }

        void Execute(Dictionary<string, string> Options);
    }
}
