using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Controller
{
    public interface IInputsListener
    {
        /// <summary>
        /// Notify the listener of a input.
        /// </summary>
        /// <param name="input">Input receive</param>
        void notify(string input);
    }
}
