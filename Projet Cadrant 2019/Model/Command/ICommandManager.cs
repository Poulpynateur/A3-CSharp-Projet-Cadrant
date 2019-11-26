using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    interface ICommandManager
    {
        List<BaseCommand> Map { get; }
    }
}
