using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        Dictionary<string, string> Options { get; }

        string Execute(Dictionary<string, string> options);

        string toString();
    }
}
