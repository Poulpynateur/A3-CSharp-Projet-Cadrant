using EasySave.Controller;
using EasySave.Model;
using EasySave.View;

namespace EasySave
{
    class App
    {
        static void Main(string[] args)
        {
            Model.Model Model = new Model.Model();
            View.View View = new View.View();

            Controller.Controller Controller = new Controller.Controller(Model, View);

            Controller.Start();
        }
    }
}
