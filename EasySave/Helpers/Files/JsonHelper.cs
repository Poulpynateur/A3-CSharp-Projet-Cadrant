using Newtonsoft.Json;
using System;
using System.IO;

namespace EasySave.Helpers.Files
{
    /// <summary>
    /// Manage Json file interactions.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Write a Json file.
        /// </summary>
        /// <param name="data">Data to write</param>
        /// <param name="path">Target path to write file</param>
        public static void WriteJson(Object data, string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }

        /// <summary>
        /// Read a json format file and parse it.
        /// </summary>
        /// <typeparam name="Data">Generic type</typeparam>
        /// <param name="path">Path to the file to read</param>
        /// <returns>The file parsed to the Data generic.</returns>
        public static Data ReadJson<Data>(string path)
        {
            if(File.Exists(path))
            {
                using (StreamReader r = new StreamReader("file.json"))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<Data>(json);
                }
            }
            else
            {
                return default(Data);
            }
        }
    }
}