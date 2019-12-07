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
        // This event is fired then an inputs is read from console
        public event IView.InputsEventHandler InputEvent;

        public View()
        {}

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
            this.DisplayText(Statut.STANDARD, "EasySave \nCopyright (C) ProSoft. All right reserved. \n\nType 'help' for commands informations.");
        }

        /// <summary>
        /// Display text to console.
        /// </summary>
        /// <param name="statut">Define the color</param>
        /// <param name="text">Text to write</param>
        public void DisplayText(Statut statut, string text)
        {
            switch (statut)
            {
                case Statut.INFO:
                    WriteConsole(ConsoleColor.DarkCyan, text);
                    break;
                case Statut.SUCCESS:
                    WriteConsole(ConsoleColor.Green, "\n" + text + "\n");
                    break;
                case Statut.WARNING:
                    WriteConsole(ConsoleColor.Yellow, text);
                    break;
                case Statut.ERROR:
                    WriteConsole(ConsoleColor.Red, "\n" + text + "\n");
                    break;
                default:
                    WriteConsole(ConsoleColor.White, "\n" + text + "\n");
                    break;
            }
        }
    }
}
