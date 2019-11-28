using System;

using EasySave.Controller;
using EasySave.Model;

namespace EasySave.View
{
    /// <summary>
    /// Display text to console and get inputs.
    /// </summary>
    class View : IView
    {
        // This event is fired then an inputs is read from console
        public event IView.InputsEventHandler InputEvent;

        public View()
        {
        }

        /// <summary>
        /// Read a line from the console.
        /// </summary>
        private void ReadConsoleLine()
        {
            string input;

            Console.Write("\n>>> ");
            input = Console.ReadLine();

            InputEvent(input);
        }

        /// <summary>
        /// Write text with color to console.
        /// </summary>
        /// <param name="color">Color of the text</param>
        /// <param name="text">Text to write</param>
        private void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Start the view.
        /// </summary>
        public void Start()
        {
            this.DisplayInfo("EasySave \nCopyright (C) ProSoft. All right reserved. \n\nType 'help' for commands informations.");
            this.ReadConsoleLine();
        }

        /// <summary>
        /// Display info text to console.
        /// </summary>
        /// <param name="text">Text to write</param>
        public void DisplayInfo(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Display warning text to console.
        /// </summary>
        /// <param name="text">Text to write</param>
        public void DisplayWarning(string text)
        {
            WriteConsole(ConsoleColor.Yellow, text);
        }

        // In case of error or success the current task
        // is finish, and we wait for the next input

        /// <summary>
        /// Display error text to console.
        /// </summary>
        /// <param name="text">Text to write</param>
        public void DisplayError(string text)
        {
            WriteConsole(ConsoleColor.Red, text);
            this.ReadConsoleLine();
        }

        /// <summary>
        /// Display success text to console.
        /// </summary>
        /// <param name="text">Text to write</param>
        public void DisplaySuccess(string text)
        {
            WriteConsole(ConsoleColor.Green, text);
            this.ReadConsoleLine();
        }
    }
}
