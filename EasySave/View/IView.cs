using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.View
{
    /// <summary>
    /// Interface to access view.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Main window
        /// </summary>
        IWindow Window { get; }

        /// <summary>
        /// Start the view.
        /// </summary>
        void Start();
    }
}
