using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.View
{
    public interface IView
    {
        delegate void InputsEventHandler(string input);
        event InputsEventHandler InputEvent;

        void Start();

        void DisplayInfo(string text);
        void DisplaySuccess(string text);
        void DisplayWarning(string text);
        void DisplayError(string text);
    }
}
