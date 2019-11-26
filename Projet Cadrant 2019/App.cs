using EasySave.Controller;
using EasySave.Model;
using EasySave.View;
using Projet_Cadrant_2019.Model;

namespace EasySave
{
    class App
    {
        static void Main(string[] args)
        {
            Model.Model model = new Model.Model();
            View.View view = new View.View(model);

            Controller.Controller controller = new Controller.Controller(model, view);

            controller.Start();
        }
    }
}
