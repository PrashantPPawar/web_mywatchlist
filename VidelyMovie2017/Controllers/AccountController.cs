using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidelyMovie2017.Models;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace VidelyMovie2017.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private MVC1Entities db2 = new MVC1Entities();
        private MVC1Entities2 db1 = new MVC1Entities2();
        // GET: Account
     public   string constr = ConfigurationManager.ConnectionStrings["MVC1Entities2"].ConnectionString;

        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
           
            con = new SqlConnection(constr);

        }
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Register1()
        {
            return View();
        }


       

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register1(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                //string cs = ConfigurationManager.ConnectionStrings["MVC1Entities2"].ConnectionString;
                using (var con = new SqlConnection(constr))
                {
                    string commandText = "Insert Into UserAccount Values (@fName,@LName,@Email,@Username,@Password)";
                    //using (var command = new SqlCommand(commandText, connection))
                    //{
                    //SqlCommand cmd = new SqlCommand(commandText);
                    //    //command.Parameters.AddWithValue("@fName", account.UserName);
                    //    //command.Parameters.AddWithValue("@LName", account.Password);
                    //    //command.Parameters.AddWithValue("@Email", account.UserName);

                    //    //command.Parameters.AddWithValue("@Username", account.Password);

                    //    //command.Parameters.AddWithValue("@Password", account.Password);
                    //    connection.Open();
                    //    SqlDataReader dr = cmd.ExecuteNonQuery();

                    // string userName = (string)command.ExecuteScalar();



                    
                    SqlCommand com = new SqlCommand("UserAdd", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@FName", account.FirstName);
                    com.Parameters.AddWithValue("@LName", account.LastName);
                    com.Parameters.AddWithValue("@Email", account.Email);
                    com.Parameters.AddWithValue("@UserName", account.UserName);
                    com.Parameters.AddWithValue("@Password", account.Password);
                    con.Open();
                    int k = com.ExecuteNonQuery();
                    if (k != 0)
                    {
                        ViewBag.Message = "Record Inserted Succesfully into the Database";
                       
                    }
                    con.Close();

                    //}
                }
                        //    //using (OurDBContent db = new OurDBContent())
                        //    //{
                        //        db1.UserAccounts.Add(account);
                        //        db1.SaveChanges();
                        //       // return RedirectToAction("Login1","Account");
                        //    //}
                        //    //ModelState.Clear();
                        ////    ViewBag.message

                        //  //  return RedirectToAction("Index");
                    }
            return View();
        }


        


        public ActionResult Login2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Login2(UserAccount account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //using (OurDBContent db = new OurDBContent())
        //        //{
        //            //var details = (from userlist in db1.Registrations
        //            //               where userlist.UserId == reg.UserId && userlist.Password == reg.Password
        //            //               select new
        //            //               {
        //            //                   userlist.UserId,
        //            //                   userlist.Email
        //            //               }).ToList();

        //            var details = db1.UserAccounts.Single(u => u.UserName == account.UserName && u.Password == account.Password);
        //            if (details != null)
        //            {
        //                Session["UserId"] =details.UserId.ToString();
        //                Session["UserName"] = details.UserName;
        //                return RedirectToAction("Dowload", "Home");
        //            }
        //        //}
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid Credentials");
        //    }
        //    return View(account);
        //}



        public ActionResult Login2(UserAccount account)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MVC1Entities2"].ConnectionString;
                using (var connection = new SqlConnection(cs))
                {
                    string commandText = "SELECT UserName FROM [UserAccount] WHERE Username=@Username AND Password = @Password";
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Username", account.UserName);
                        command.Parameters.AddWithValue("@Password", account.Password);
                        connection.Open();

                        string userName = (string)command.ExecuteScalar();

                        if (!String.IsNullOrEmpty(userName))
                        {
                            System.Web.Security.FormsAuthentication.SetAuthCookie(account.UserName, false);
                            return RedirectToAction("Dowload", "Home"); ;
                        }
                        else
                        {
                            TempData["Message"] = "Login failed.User name or password supplied doesn't exist.";
                            
                        }

                       

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Login failed.Error - " + ex.Message;
            }
            //return RedirectToAction("Index");
            return View(account);
        }


    }
}