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

        /// <summary>
        /// Display info.
        /// </summary>
        /// <param name="text">Text to display</param>
        void DisplayInfo(string text);

        /// <summary>
        /// Display success.
        /// </summary>
        /// <param name="text">Text to display</param>
        void DisplaySuccess(string text);

        /// <summary>
        /// Display warning.
        /// </summary>
        /// <param name="text">Text to display</param>
        void DisplayWarning(string text);

        /// <summary>
        /// Display error.
        /// </summary>
        /// <param name="text">Text to display</param>
        void DisplayError(string text);
    }
}
