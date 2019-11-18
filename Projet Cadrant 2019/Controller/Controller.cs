using Projet_Cadrant_2019.Model;
using Projet_Cadrant_2019.View;

namespace Projet_Cadrant_2019.Controller
{
    class Controller : IInputsListener
    {
        private IModel model;
        private IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        /// <summary>
        /// Start the main programm..
        /// </summary>
        public void start()
        {
            view.readConsoleLine();
        }

        /// <summary>
        /// <see cref="IInputsListener">IInputsListener</see>.
        /// </summary>
        public void notify(string input)
        {
            view.writeConsoleLine("Your input : " + input);
            view.readConsoleLine();
        }
    }
}
