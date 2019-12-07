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
        /// Handle inputs from the console.
        /// </summary>
        /// <param name="input"></param>
        delegate void InputsEventHandler(string input);
        /// <summary>
        /// Event that triggered on console inputs.
        /// </summary>
        event InputsEventHandler InputEvent;

        /// <summary>
        /// Start the view.
        /// </summary>
        void Start();
        void DisplayText(Statut statut, string text);
    }
}
