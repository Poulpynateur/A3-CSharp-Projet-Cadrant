using EasySave.Model.Command;

namespace EasySave.Model
{
    public interface IModel 
    {
        public ICommandManager Jobs { get; }
    }
}
