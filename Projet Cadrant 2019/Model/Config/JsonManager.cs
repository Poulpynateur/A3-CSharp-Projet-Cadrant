using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Projet_Cadrant_2019.Model
{
    public class Data
    {
        public Data()
        {

        }
        public Data(string pathfrom, string pathto, long size, string transferetime)
        {
            Pathfrom = pathfrom;
            Pathto = pathto;
            Date = DateTime.Now.ToString();
            SaveName = "Sav_" + DateTime.Now.ToString().Replace('/', '_').Replace(':', '-');
            Size = size;
            TransfereTime = transferetime;
        }
        public string Date { get; set; }
        public string Pathto { get; set; }
        public string Pathfrom { get; set; }
        public string SaveName { get; set; }
        public long Size { get; set; }
        public string TransfereTime { get; set; }
    }

    public class JsonManager
    {
        public Data readdata = new Data();
        public void WriteJsonFileHistory(Data data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString;
            jsonString = JsonSerializer.Serialize(data, options);
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json", jsonString + ",");
            Console.WriteLine(jsonString);
            string path = Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json";
            Console.WriteLine(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json");
        }
        public void WriteJsonProgress(DataFiles datafiles)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString;
            jsonString = JsonSerializer.Serialize(datafiles, options);
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\Progress.json", jsonString + ",");
            Console.WriteLine(jsonString);
        }
        /*public void ReadJsonFile()
        {
            string jsonString;
            jsonString = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json");
            readdata = JsonSerializer.Deserialize<Data>(jsonString);
            Type t = typeof(Data);
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propInfo in propInfos)
            {
                Console.WriteLine(propInfo.Name);
                Console.WriteLine(propInfo.GetValue(readdata));
                Console.WriteLine();
            }
        }*/
    }
    public class DataFiles
    {
        public DataFiles(int filesnbrtotal, int filesnbrremaining, double sizetotal, double sizeremaining, string filename)
        {
            Date = DateTime.Now.ToString();
            FilesNbrTotal = filesnbrtotal;
            FilesNbrRemaining = filesnbrremaining;
            SizeTotal = sizetotal;
            SizeRemaining = sizeremaining;
            FileName = filename;
            int Progress = (int)((sizetotal - sizeremaining) * 100 / sizetotal);
            PercentProgress = Progress + "%";
        }
        public int FilesNbrTotal { get; set; }
        public string Date { get; set; }
        public int FilesNbrRemaining { get; set; }
        public double SizeTotal { get; set; }
        public double SizeRemaining { get; set; }
        public string FileName { get; set; }
        public string PercentProgress { get; set; }
    }
}
