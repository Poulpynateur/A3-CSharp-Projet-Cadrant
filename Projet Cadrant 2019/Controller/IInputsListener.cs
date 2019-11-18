using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Cadrant_2019.Controller
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
