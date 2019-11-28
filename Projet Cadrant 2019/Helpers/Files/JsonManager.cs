using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace EasySave.Helpers.Files
{
    /// <summary>
    /// Manage Json file interactions.
    /// </summary>
    public class JsonManager
    {
        /// <summary>
        /// Write a Json file.
        /// </summary>
        /// <param name="data">Data to write</param>
        /// <param name="path">Target path to write file</param>
        public void WriteJson(Object data, string path)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, jsonString);
        }

        /// <summary>
        /// Read a json format file and parse it.
        /// </summary>
        /// <typeparam name="Data">Generic type</typeparam>
        /// <param name="path">Path to the file to read</param>
        /// <returns>The file parsed to the Data generic.</returns>
        public Data ReadJson<Data>(string path)
        {
            if(File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Data>(jsonString);
            }
            else
            {
                return default(Data);
            }
        }
    }
}