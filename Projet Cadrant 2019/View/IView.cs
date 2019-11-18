using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.View
{
    public interface IView
    {
        public delegate void InputsEventHandler(string input);
        public event InputsEventHandler inputEvent;

        /// <summary>
        /// Write some text to the console.
        /// </summary>
        /// <param name="text">Text to write</param>
        void writeConsoleLine(string text);

        /// <summary>
        /// Read line from the console.
        /// </summary>
        void readConsoleLine();
    }
}
