﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Cadrant_2019.View
{
    public interface IView
    {
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
