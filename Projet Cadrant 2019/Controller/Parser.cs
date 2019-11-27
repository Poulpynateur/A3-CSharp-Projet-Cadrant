using EasySave.Model;
using EasySave.View;
using System.Collections.Generic;
using System;

namespace EasySave.Controller
{
    public class Parser
    {
        private char[] trimChars;

        public Parser()
        {
            this.trimChars = new char[]{ ' ', ';', '\'', '.', '\t' };
        }

        /// <summary>
        /// Method which returns the name of the command
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Command Name</returns>
        public string ParseName(string input)
        {
            // Remove some char at the start and the end of the string
            input = input.Trim(trimChars);

            // Retrieves the first name corresponding to the name of the command and then returns it
            if (input.Contains(" "))
                input = input.Substring(0, input.IndexOf(" "));

            return input;
        }

        /// <summary>
        /// Method that returns a dictionary containing the name of the option and its value
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Command Option Name and Value</returns>
        public Dictionary<string, string> ParseOptions(string input)
        {
            Dictionary<string, string> dicoCommandOptions = new Dictionary<string, string>();

            if (input.Contains(" "))
            {
                // Delete the first word (Command name)
                input = input.Substring(input.IndexOf(" "));

                // Remove some char at the start and the end of the string
                input = input.Trim(trimChars);

                // Split the input with the '-' delimitor and adds the tuple to the dictionnary for option
                string[] splits = input.Split('-');
                foreach (string split in splits)
                {
                    if (split.Length > 0)
                    {
                        // Initialize the key and value for each option in the input and add them in the dictionary
                        string key = split.Substring(0, split.IndexOf(" "));
                        string value = split.Substring(split.IndexOf(" "));
                        value = value.Trim(trimChars);
                        
                        // Throw an exception if the key is already in the dictionary. Will be caught in the Controller
                        if (dicoCommandOptions.ContainsKey(key))
                        {
                            throw new ArgumentException("An element with the key " + key + " already exists");
                        }

                        dicoCommandOptions.Add(key, value);
                    }
                }
            }

            return dicoCommandOptions;
        }
    }
}
