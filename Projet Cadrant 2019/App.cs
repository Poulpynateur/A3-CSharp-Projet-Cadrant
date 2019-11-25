using EasySave.Controller;
using EasySave.Model;
using EasySave.View;

namespace EasySave
{
    class App
    {
        static void Main(string[] args)
        {
            JsonManager json = new JsonManager();
            json.WriteJsonFileHistory();
            //json.ReadJsonFile();
            Model.Model model = new Model.Model();
            View.View view = new View.View(model);

            Controller.Controller controller = new Controller.Controller(model, view);

            controller.Start();
        }
    }
}
