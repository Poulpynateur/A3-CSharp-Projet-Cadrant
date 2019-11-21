using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public interface ICommand
    {
        string Name { get; set; }

        string Description { get; set; }

        Dictionary<string, string> Options { get; }

        void Execute(Dictionary<string, string> Options);

    }
}
