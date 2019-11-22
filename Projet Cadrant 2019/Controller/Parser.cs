using EasySave.Model;
using EasySave.View;
using System.Collections.Generic;

namespace EasySave.Controller
{
    public class Parser
    {
        public ParsedCommand ParseCommand(string input)
        {
            return new ParsedCommand(input, new Dictionary<string, string>());
        }
    }
}
