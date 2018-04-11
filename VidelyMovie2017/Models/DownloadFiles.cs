using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using VidelyMovie2017.Models;

namespace VidelyMovie2017.Models
{
    public class DownloadFiles
    {
        //public int FileId { get; private set; }
        //public string FileName { get; private set; }
        //public string FilePath { get; private set; }

        public List<DownloadFileInfo> GetFiles()
        {
            List<DownloadFileInfo> lstFiles = new List<DownloadFileInfo>();
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(HostingEnvironment.MapPath("~/Images"));

            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                lstFiles.Add(new DownloadFileInfo()
                {

                    FileId = i,
                    FileName = item.Name,
                    FilePath = dirInfo.FullName + @"\" + item.Name
                });
                i = i;
            }
            return lstFiles;
        }
    }
}