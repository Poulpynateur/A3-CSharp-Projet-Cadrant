using System;

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
        private IModel model;
        public IWindow Window { get; private set; }

        public View(IModel model)
        {
            this.model = model;
            Window = new MainWindow(model);
        }

        /// <summary>
        /// Start the view.
        /// </summary>
        public void Start()
        {
            this.model.GetDisplayable().DisplayUpdateEvent += Window.DisplayText;
            this.Window.Show();
        }
    }
}
