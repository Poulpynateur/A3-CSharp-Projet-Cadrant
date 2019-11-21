using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public interface ICommandManager
    {

        void GetCommandes();

        void ExecuteCommand(string Name, string[] Options);
    }
}
