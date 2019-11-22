using EasySave.Model;
using EasySave.View;

namespace EasySave.Controller
{
    class Controller
    {
        private IModel model;
        private IView view;

        private Parser parser;

        public Controller(IModel Model, IView View)
        {
            this.model = Model;
            this.view = View;

            this.parser = new Parser();

            this.HandleEvents();
        }

        private void HandleEvents()
        {
            view.InputEvent += delegate (string input)
            {
                ParsedCommand command = parser.ParseCommand(input);
                if(model.CommandManager.Commands.Find(cmd => cmd.Name == command.Name) != null)
                    model.CommandManager.ExecuteCommand(command.Name, command.Options);
                else
                    view.WriteConsoleLine("Command doesn't exist, use command help for a list of commands.");

                view.ReadConsoleLine();
            };
        }

        /// <summary>
        /// Start the main programm..
        /// </summary>
        public void Start()
        {
            view.ReadConsoleLine();
        }
    }
}
