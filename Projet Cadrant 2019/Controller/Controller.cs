using EasySave.Model;
using EasySave.View;

namespace EasySave.Controller
{
    class Controller
    {
        private IModel model;
        private IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;

            this.handleEvents();
        }

        private void handleEvents()
        {
            view.inputEvent += delegate (string input)
            {
                view.writeConsoleLine("Your input : " + input);
                view.readConsoleLine();
            };
        }

        /// <summary>
        /// Start the main programm..
        /// </summary>
        public void start()
        {
            view.readConsoleLine();
        }
    }
}
