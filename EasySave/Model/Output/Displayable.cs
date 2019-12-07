using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Output
{
    public class Displayable : IDisplayable
    {
        public event IDisplayable.DisplayUpdate DisplayUpdateEvent;

        public void DisplayText(Statut statut, string text)
        {
            DisplayUpdateEvent(statut, text);
        }
    }
}
