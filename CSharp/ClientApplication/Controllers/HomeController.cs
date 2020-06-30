using ClientApplication.Models;
using ClientWCF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection con = new SqlConnection(@"Data Source=lenovo-odeb;Initial Catalog=ClientApplication;Integrated Security=True");
        public ServiceClient WCFClient = new ServiceClient();
        public List<string> file_user = new List<string>();
        public List<string> file_name = new List<string>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authentification()
        {
            return View();
        }

        public ActionResult Decryptage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From UserList where Firstname ='" + user.userName + "' and UserPassword ='" + user.password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sdb = new SqlDataAdapter("Update UserList set State = 1 where Firstname ='" + user.userName + "' and UserPassword ='" + user.password + "'" , con);
                sdb.Fill(dt);
                Response.Redirect("~/Home/Authentification");
            }
            else
            {
                ViewBag.Message = user;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Authentification(User user)
        {
            string TokenUser = WCFClient.TokenApp(user.tokenApp) ;
            
            if (TokenUser != null)
            {
                ViewData["TokenUser"] = "Votre TokenUser est : " + TokenUser;
                ViewData["TokenApp"] = user.tokenApp;
                //Response.Redirect("~/Home/Decryptage");
                ViewData["TokenUser_Pass"] = 1;
            }

            else
            {

                // ViewBag.Message = "wrong";
                ViewData["TokenUser_Pass"] = 0;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Decryptage(HttpPostedFileBase[] UploadedFile)
        {
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file_current in UploadedFile)
                {
                    int i = 0;
                    if (file_current != null)
                    {
                        i = i++;
                        List<string> csvData = new List<string>();
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(file_current.InputStream))
                        {
                            while (!reader.EndOfStream)
                            {
                                csvData.Add(reader.ReadLine());
                            }
                        }
                        file_user.Add(string.Join(" ", csvData.ToArray()));
                        file_name.Add(Path.GetFileName(file_current.FileName));
                        var FolderSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + file_name[i]);
                        //Save file to server folder  
                        file_current.SaveAs(FolderSavePath);
                        //envoi de données vers WCF 
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.Message = UploadedFile.Count().ToString() + " fichiers ont été uploadés avec succés.";
                    }
                }

                WCFClient.DecryptLauncher(file_user, file_name);
            }

            return View();
        }

     /*   [HttpPost]
        public ActionResult Decryptage(User user)
        {
            if (user.tokenUser != null)
            {

            }

            return View();
        }*/
    }
}