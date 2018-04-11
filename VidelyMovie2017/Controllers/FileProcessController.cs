using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidelyMovie2017.Models;
using System.IO;

namespace VidelyMovie2017.Controllers
{
    public class FileProcessController : Controller
    {

        //DownloadFiles obj;
        //public FileProcessController()
        //{
        //    obj = new DownloadFiles();
        //}

        public ActionResult Index()
        {
            //var filesCollection = obj.GetFiles();
            //return View(filesCollection);

            System.IO.DirectoryInfo salesFTPDirectory = null;
            System.IO.FileInfo[] files = null;

            try
            {
                string salesFTPPath = "D:/Prashant";
                salesFTPDirectory = new DirectoryInfo(salesFTPPath);
                files = salesFTPDirectory.GetFiles();
            }
            catch (DirectoryNotFoundException exp)
            {
                throw new Exception("Could not open the ftp directory", exp);
            }
            catch (IOException exp)
            {
                throw new Exception("Failed to access directory", exp);
            }

            files = files.OrderBy(f => f.Name).ToArray();

            var salesFiles = files.Where(f => f.Extension == ".xls" || f.Extension == ".xml");

            return View(salesFiles);
        }


        public ActionResult Dowload()
        {
            ViewBag.Message = "Your Download page.";

            return View();

            //var filesCollection = obj.GetFiles();
            //return View(filesCollection);
        }
        //public FileResult Download(string FileID)
        //{
        //    #region Code1
        //    int CurrentFileID = Convert.ToInt32(FileID);
        //    var filesCol = obj.GetFiles();
        //    string CurrentFileName = (from fls in filesCol
        //                              where fls.FileId == CurrentFileID
        //                              select fls.FilePath).First();

        //    string contentType = string.Empty;

        //    if (CurrentFileName.Contains(".pdf"))
        //    {
        //        contentType = "application/pdf";
        //    }

        //    else if (CurrentFileName.Contains(".docx"))
        //    {
        //        contentType = "application/docx";
        //    }
        //    return File(CurrentFileName, contentType, CurrentFileName);
        //    #endregion



        //}
    }
}