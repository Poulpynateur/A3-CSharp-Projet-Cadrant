using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Class implementing the Dictionary
    /// </summary>
    public class LangFormat : Dictionary<string, Dictionary<string, string>> { }

    /// <summary>
    /// Class used to manage the language of the application
    /// </summary>
    public class Lang
    {
        /// <summary>
        /// Actual language
        /// </summary>
        public string LangActual { get; set; }

        /// <summary>
        /// Language choosen to change to.
        /// </summary>
        public string[] LangChoice { get; }

        /// <summary>
        /// Dictionary
        /// </summary>
        private LangFormat text;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">LangFormat object</param>
        public Lang(LangFormat text)
        {
            string[] separator = { ";" };

            this.text = text;
            LangChoice = text["lang_parameters"]["avaible"].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            LangActual = LangChoice[0];
        }

        /// <summary>
        /// Translate from the actual language to the choosen one
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string Translate(string target)
        {
            if (LangActual.Equals("eng"))
                return target;

            try
            {
                return text[target][LangActual];
            }
            catch
            {
                return target;
            }
        }
    }
}
