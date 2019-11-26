using EasySave.Controller;
using EasySave.Model;
using EasySave.Model.Command;
using EasySave.View;
using Projet_Cadrant_2019.Model;

namespace EasySave
{
    class App
    {
        static void Main(string[] args)
        {

            string pathfrom = "C:\\Users\\lucas\\OneDrive - Association Cesi Viacesi mail\\Documents\\Cesi";
            string pathto = "C:\\Users\\lucas\\OneDrive - Association Cesi Viacesi mail\\Documents\\TestSav";
            SaveMirror save = new SaveMirror(pathfrom, pathto);
            save.CopyFiles();

            Model.Model model = new Model.Model();
            View.View view = new View.View(model);

            Controller.Controller controller = new Controller.Controller(model, view);

            controller.Start();
        }
    }
}
