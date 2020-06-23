using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection con = new SqlConnection(@"Data Source=JIREN-SAMA;Initial Catalog=ClientApplication;Integrated Security=True");

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ContentResult Index(User user)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From UserList where Firstname ='" + user.userName + "' and UserPassword ='" + user.password + "'", con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Response.Write("Vous êtes connecté");
                //ViewBag.Message = "Vous êtes connecté";
            }
            else
            {
                ViewBag.Message("Invalid username or password");
            }

            return Content(user.userName + " " + user.password);
        }

    }
}