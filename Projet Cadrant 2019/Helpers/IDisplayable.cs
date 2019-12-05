using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Helpers
{
    public enum Statut
    {
        STANDARD,
        INFO,
        SUCCESS,
        ERROR,
        WARNING
    }

    public interface IDisplayable
    {
        delegate void DisplayUpdate(Statut statut, string text);
        event DisplayUpdate DisplayUpdateEvent;
    }
}
