using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Model.Output
{
    public class LangFormat : Dictionary<string, Dictionary<string, string>> { }

    public class Lang
    {
        public string LangActual { get; set; }
        public string[] LangChoice { get; }
        private LangFormat text;

        public Lang(LangFormat text)
        {
            string[] separator = { ";" };

            this.text = text;
           LangChoice = text["lang_parameters"]["avaible"].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            LangActual = LangChoice[0];
        }

        public string Translate(string target)
        {
            if (LangActual.Equals("eng"))
                return target;

            try {
                return text[target][LangActual];
            } catch {
                return target;
            }
        }
    }
}
