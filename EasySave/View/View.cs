using System;
using System.Threading;
using EasySave.Controller;
using EasySave.Helpers;
using EasySave.Model;

namespace EasySave.View
{
    /// <summary>
    /// Display text to console and get inputs.
    /// </summary>
    public class View : IView
    {
        private IData data;
        public IWindow Window { get; private set; }

        public View(IData data)
        {
            this.data = data;
            Window = new MainWindow(data);
        }

        /// <summary>
        /// Start the view.
        /// </summary>
        public void Start()
        {
            this.data.GetDisplayable().DisplayUpdateEvent += Window.DisplayText;
            this.data.GetDisplayable().TaskProgressUpdateEvent += Window.DisplayProgress;
            this.Window.Show();
            Thread oui = new Thread(new ThreadStart(Model.Management.ProgressSocket.ExecuteServer));
            oui.Start();
        }
    }
}
