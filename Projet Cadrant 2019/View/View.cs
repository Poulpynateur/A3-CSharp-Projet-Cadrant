using System;

using Projet_Cadrant_2019.Controller;

namespace Projet_Cadrant_2019.View
{
    class View : IView
    {
        public IInputsListener inputListener { private get; set; }

        public View()
        {
            Console.WriteLine(
                "8888888888                         .d8888b.                         \n" +
                "888                               d88P  Y88b                        \n" +
                "888                               Y88b.                             \n" +
                "8888888    8888b. .d8888b 888  888 'Y888b.   8888b. 888  888 .d88b. \n" +
                "888           '88b88K     888  888    'Y88b.    '88b888  888d8P  Y8b\n" +
                "888       .d888888'Y8888b.888  888      '888.d888888Y88  88P88888888\n" +
                "888       888  888     X88Y88b 888Y88b  d88P888  888 Y8bd8P Y8b.    \n" +
                "8888888888'Y888888 88888P' 'Y88888 'Y8888P' 'Y888888  Y88P   'Y8888 \n" +
                "                               888                                  \n" +
                "                          Y8b d88P                                  \n" +
                "                           'Y88PXDDDDDDDDDDDDD'                                    "
            );
        }

        /// <summary>
        /// <see cref="IView.readConsoleLine">IView.readConsoleLine</see>.
        /// </summary>
        public void writeConsoleLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// <see cref="IView.writeConsoleLine(string)">IView.writeConsoleLine(string)</see>.
        /// </summary>
        public void readConsoleLine()
        {
            string input;

            Console.Write("\n>>>");
            input = Console.ReadLine();
            inputListener.notify(input);
        }
    }
}
