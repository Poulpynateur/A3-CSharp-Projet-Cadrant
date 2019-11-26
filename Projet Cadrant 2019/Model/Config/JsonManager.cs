using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;


namespace Projet_Cadrant_2019.Model
{
    public class JsonManager
    {
        //method writting the history of backup jobs in JSON format
        public static void WriteJsonFileHistory(DataFiles datafiles)
        {
            //options of JSON serializing which exclude properties with null values and indenting the JSON text
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true,
            };
            //Converts the object containing the history log properties into a JSON string
            string jsonString = JsonSerializer.Serialize(datafiles, options);
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json", jsonString + ",");
            //Console.WriteLine(jsonString);
            string path = Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json";
            //Console.WriteLine(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json");
        }
        public static void WriteJsonProgress(DataFiles datafiles)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true,
            };
            string jsonString;
            jsonString = JsonSerializer.Serialize(datafiles, options);
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\Progress.json", jsonString + ",");
            Console.WriteLine(jsonString);
        }
    }
    public class DataFiles
    {
        //Constructor used to create JSON history
        public DataFiles(string pathfrom, string pathto, long totalsize, string transferetime)
        {
            Date = DateTime.Now.ToString();
            Pathfrom = pathfrom;
            Pathto = pathto;
            SaveName = "Sav_" + DateTime.Now.ToString().Replace('/', '_').Replace(':', '-');
            SizeTotal = totalsize;
            TransfereTime = transferetime;
        }
        //Constructor used to create JSON progress
        public DataFiles(int filesnbrtotal, int filesnbrremaining, double sizetotal, double sizeremaining, string filename)
        {
            Date = DateTime.Now.ToString();
            FilesNbrTotal = filesnbrtotal.ToString();
            FilesNbrRemaining = filesnbrremaining.ToString();
            SizeTotal = (long)sizetotal;
            SizeRemaining = sizeremaining.ToString();
            FileName = filename;
            int Progress = (int)((sizetotal - sizeremaining) * 100 / sizetotal);
            PercentProgress = Progress + "%";
        }
        public string Pathfrom { get;}
        public string Pathto { get;}
        public string SaveName { get; }
        public long SizeTotal { get; }
        public string TransfereTime { get; }
        public string FilesNbrTotal { get; }
        public string Date { get; }
        public string FilesNbrRemaining { get; }
        public string SizeRemaining { get; }
        public string FileName { get; }
        public string PercentProgress { get; }
    }

    /*public void ReadJsonFile()
    {
        string jsonString;
        jsonString = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json");
        readdata = JsonSerializer.Deserialize<DataFiles>(jsonString);
        Type t = typeof(DataFiles);
        PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var propInfo in propInfos)
        {
            Console.WriteLine(propInfo.Name);
            Console.WriteLine(propInfo.GetValue(readdata));
            Console.WriteLine();
        }
    }*/
}
