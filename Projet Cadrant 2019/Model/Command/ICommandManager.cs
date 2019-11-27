using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public interface ICommandManager
    {
        List<BaseCommand> Map { get; }
        BaseCommand getCmdByName(string name);
    }
}
