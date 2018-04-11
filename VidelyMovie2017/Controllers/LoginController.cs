using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace VidelyMovie2017.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        //public ActionResult Login()
        //{
        //    string Path = Server.MapPath("~/Images/");
        //    //  string Path = Server.MapPath("F:/SW");

        //    DirectoryInfo dirInfo = new DirectoryInfo(Path);
        //    FileInfo[] files = dirInfo.GetFiles("*.*");
        //    List<string> lst = new List<string>(files.Length);
        //    foreach (var item in files)
        //    {
        //        lst.Add(item.Name);

        //    }

        //    return View(lst);


        //}


        //public ActionResult DownloadFile(string filename)
        //{
        //    string contentType = string.Empty;
        //    if (Path.GetExtension(filename) == ".png")
        //    {
        //        string fullpath = Path.Combine(Server.MapPath("~/Images/"), filename);
        //        return File(fullpath, "Images/png", filename);
        //    }
        //    else if (Path.GetExtension(filename) == ".pdf")
        //    {
        //        string fullpath = Path.Combine(Server.MapPath("~/Images/"), filename);
        //        return File(fullpath, "Images/pdf", filename);
        //    }
        //    else if (Path.GetExtension(filename) == ".rar")
        //    {
        //        string fullpath = Path.Combine(Server.MapPath("~/Images/"), filename);
        //        contentType = "application/rar";
        //        // return File(fullpath, "Images/rar");
        //        //return File(filename, contentType, filename);
        //        return File(fullpath, "Images/rar", filename);

        //    }
        //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
        //}
    }
}