using System;

using EasySave.Controller;
using EasySave.Model;

namespace EasySave.View
{
    class View : IView
    {

        private IModel data;

        public event IView.InputsEventHandler InputEvent;

        public View(IModel model)
        {
            this.data = model;
        }

        private void ReadConsoleLine()
        {
            string input;

            Console.Write("\n>>> ");
            input = Console.ReadLine();

            InputEvent(input);
        }
        private void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void Start()
        {
            this.ReadConsoleLine();
        }

        public void DisplayInfo(string text)
        {
            Console.WriteLine(text);
        }

        public void DisplayWarning(string text)
        {
            WriteConsole(ConsoleColor.Yellow, text);
        }

        // In case of error or success the current task
        // is finish, wait for next input
        public void DisplayError(string text)
        {
            WriteConsole(ConsoleColor.Red, text);
            this.ReadConsoleLine();
        }
        public void DisplaySuccess(string text)
        {
            WriteConsole(ConsoleColor.Green, text);
            this.ReadConsoleLine();
        }
    }
}
