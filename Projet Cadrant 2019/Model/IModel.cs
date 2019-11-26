using EasySave.Model.Command;
using System.Collections.Generic;

namespace EasySave.Model
{
    public interface IModel 
    {
        BaseCommand getCmdByName(string name);
    }
}
