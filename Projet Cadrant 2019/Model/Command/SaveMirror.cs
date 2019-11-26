﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Projet_Cadrant_2019.Model;
using static Projet_Cadrant_2019.Model.JsonManager;

namespace EasySave.Model.Command
{
    class SaveMirror
    {
        delegate void DelegateJson(DataFiles data);
        private string PathFrom { get; set; }
        private string PathTo { get; set; }
        public SaveMirror(string pathfrom, string pathto)
        {
            PathFrom = pathfrom;
            PathTo = pathto;
        }
        public void CopyFiles()
        {
            DateTime startdate = DateTime.Now;
            int totalnbrfiles = 0;
            string[] files = Directory.GetFiles(PathFrom, "*", SearchOption.AllDirectories);
            string[] directories = Directory.GetDirectories(PathFrom, "*", SearchOption.AllDirectories);
            DirectoryInfo dir = new DirectoryInfo(PathFrom);
            FileInfo[] filess = dir.GetFiles("*.*", SearchOption.AllDirectories);
            long totalByteSize = filess.Sum(f => f.Length);
            foreach (string directory in directories)
            {
                //i += 1;
                string relpath = directory.Replace(PathFrom, "");
                string pathdef = PathTo + relpath;
                Directory.CreateDirectory(pathdef);
            }
            foreach (string file in files)
            {
                totalnbrfiles += 1;
            }
            int nbrremainingfiles = totalnbrfiles;
            long totalByteSizeRemain = totalByteSize;
            foreach (string file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                totalByteSizeRemain -= fileinfo.Length;
                string relpath = file.Replace(PathFrom, "");
                string pathdef = PathTo + relpath;
                File.Copy(file, pathdef, true);
                nbrremainingfiles -= 1;
                DataFiles datafiles = new DataFiles(totalnbrfiles, nbrremainingfiles, totalByteSize, totalByteSizeRemain, file);
                WriteJsonProgress(datafiles);
            }
            TimeSpan transferetime = DateTime.Now - startdate;
            string transferetimems = ((long)transferetime.TotalMilliseconds + " ms");
            DataFiles datafileshistory = new DataFiles(PathFrom, PathTo, totalByteSize, transferetimems);
            WriteJsonFileHistory(datafileshistory);
        }
    }
}
