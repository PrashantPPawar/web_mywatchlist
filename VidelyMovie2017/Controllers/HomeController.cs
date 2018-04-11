using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using VidelyMovie2017.Models;
using System.Linq;

namespace VidelyMovie2017.Controllers
{
    public class HomeController : Controller
    {
        #region Declaration
        //  private DatabaseFirstDbEntities db = new DatabaseFirstDbEntities();
     //   private DatabaseFirstDbEntities db = new DatabaseFirstDbEntities();
        private MVC1Entities db1 = new MVC1Entities();
        // private DataAnnotationsModelMetadata db=new DataAnnotationsModelMetadata();
        #endregion


        public ActionResult Index()
        {
            return View();

            //var filesCollection = obj.GetFiles();
            //return View(filesCollection);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult Dowload()
        //{
        //    ViewBag.Message = "Your Download page.";

        //    return View();


        //}

        public ActionResult Dowload()
        {
            string Path = Server.MapPath("~/Images/");
            //  string Path = Server.MapPath("F:/SW");

            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            FileInfo[] files = dirInfo.GetFiles("*.*");
            List<string> lst = new List<string>(files.Length);
            foreach (var item in files)
            {
                lst.Add(item.Name);

            }

            return View(lst);


        }


        public ActionResult DownloadFile(string filename)
        {
            string contentType = string.Empty;
            if (Path.GetExtension(filename) == ".png")
            {
                string fullpath = Path.Combine(Server.MapPath("~/Images/"), filename);
                return File(fullpath, "Images/png", filename);
            }
            else if (Path.GetExtension(filename) == ".pdf")
            {
                string fullpath = Path.Combine(Server.MapPath("~/Images/"), filename);
                return File(fullpath, "Images/pdf", filename);
            }
            else if (Path.GetExtension(filename) == ".rar")
            {
                string fullpath = Path.Combine(Server.MapPath("~/Images/"), filename);
                contentType = "application/rar";
                // return File(fullpath, "Images/rar");
                //return File(filename, contentType, filename);
                return File(fullpath, "Images/rar", filename);

            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
        }

        public ActionResult Login1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login1(Registration reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db1.Registrations
                               where userlist.UserId == reg.UserId && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.UserId,
                                   userlist.Email
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["UserId"] = details.FirstOrDefault().UserId;
                    Session["Email"] = details.FirstOrDefault().Email;
                    return RedirectToAction("Dowload","Home");
                }
            }
            else
            {
                ModelState.AddModelError("","Invalid Credentials");
            }
            return View(reg);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(Registration reg)
        {
            if (ModelState.IsValid)
            {
                db1.Registrations.Add(reg);
                db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }

    internal class DatabaseFirstDbEntities
    {
        public object Registration { get; internal set; }
    }
}