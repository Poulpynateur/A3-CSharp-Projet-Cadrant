using EasySave.Model;
using EasySave.View;
using System.Collections.Generic;

namespace EasySave.Controller
{
    public class Parser
    {
        public string ParseName(string input)
        {
            return "test";
        }
        public Dictionary<string, string> ParseOptions(string input)
        {
            return new Dictionary<string, string>
            {
                { "o", "success" }
            };
        }
    }
}
