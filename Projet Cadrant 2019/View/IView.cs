using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.View
{
    public interface IView
    {
        public delegate void InputsEventHandler(string Input);
        public event InputsEventHandler InputEvent;

        /// <summary>
        /// Write some text to the console.
        /// </summary>
        /// <param name="Text">Text to write</param>
        void WriteConsoleLine(string Text);

        /// <summary>
        /// Read line from the console.
        /// </summary>
        void ReadConsoleLine();
    }
}
