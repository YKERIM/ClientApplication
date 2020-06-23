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
        private String username;
        private String password;
        private String tokenapp;
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ContentResult Index(User user)
        {
            return Content(user.userName + " " + user.password);
        }

        public void logButton(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=GEARLESS-JOE;Initial Catalog=ClientDatabase;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select FirstName,UserPassword, TokenApp From UserList where Firstname ='" + username + "' and UserPassword ='" + password + "' and TokenApp='"+ tokenapp +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }
    }
}