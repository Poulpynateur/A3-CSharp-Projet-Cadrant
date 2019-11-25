using Projet_Cadrant_2019.Controller;
using Projet_Cadrant_2019.Model;
using Projet_Cadrant_2019.View;

namespace Projet_Cadrant_2019
{
    class App
    {
        static void Main(string[] args)
        {
            JsonManager json = new JsonManager();
            json.WriteJsonFileHistory();
            //json.ReadJsonFile();
            Model.Model model = new Model.Model();
            View.View view = new View.View();

            Controller.Controller controller = new Controller.Controller(model, view);

            view.inputListener = controller;

            controller.start();
        }
    }
}
