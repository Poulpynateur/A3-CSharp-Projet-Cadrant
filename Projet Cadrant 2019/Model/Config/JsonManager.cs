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
        public Data(string pathfrom, string pathto, string size, string transferetime)
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
        public string Size { get; set; }
        public string TransfereTime { get; set; }
    }

    public class JsonManager
    {
        public Data data = new Data("FROM", "TO", "1288 Mo", "2080 ms");
        public Data readdata = new Data();
        public DataFiles datafiles = new DataFiles(314, 157, 2080, 1080, "test.txt");
        public void WriteJsonFileHistory()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString;
            jsonString = JsonSerializer.Serialize(data, options);
            //File.WriteAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json", jsonString);
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json", jsonString + ",");
            Console.WriteLine(jsonString);
            string path = Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json";
            Console.WriteLine(Directory.GetCurrentDirectory() + "\\Journal_sav\\History_log.json");
        }
        public void WriteJsonProgress()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString;
            jsonString = JsonSerializer.Serialize(datafiles, options);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\Journal_sav\\Progress.json", jsonString);
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
        public DataFiles(int filesnbrtotal, int filesnbrremaining, int sizetotal, int sizeremaining, string filename)
        {
            Date = DateTime.Now.ToString();
            FilesNbrTotal = filesnbrtotal;
            FilesNbrRemaining = filesnbrremaining;
            SizeTotal = sizetotal;
            SizeRemaining = sizeremaining;
            FileName = filename;
            int Progress = sizeremaining * 100/sizetotal;
            PercentProgress = Progress + "%";
        }
        public int FilesNbrTotal { get; set; }
        public string Date { get; set; }
        public int FilesNbrRemaining { get; set; }
        public int SizeTotal { get; set; }
        public int SizeRemaining { get; set; }
        public string FileName { get; set; }
        //public int Progress { get; set; }
        public string PercentProgress { get; set; }
    }
}
