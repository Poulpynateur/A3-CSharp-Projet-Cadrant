using EasySave.Model.Command;
using System.Collections.Generic;

namespace EasySave.Model
{
    /// <summary>
    /// Interface to access model.
    /// </summary>
    public interface IModel 
    {
        BaseCommand getCmdByName(string name);
    }
}
