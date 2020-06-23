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
            SqlConnection con = new SqlConnection(@"Data Source=GEARLESS-JOE;Initial Catalog=ClientDatabase;Integrated Security=True");
            String query = "Select FirstName,UserPassword From UserList where Firstname ='" + user.userName + "' and UserPassword ='" + user.password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            String output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                ViewBag.Message = "Vous êtes connecté";
            }
            else
            {
                Response.Write("Veuillez vérifier vos informations");
            }
            return Content(user.userName + " " + user.password);
        }

        public void logButton(object sender, EventArgs e)
        {

            /*SqlConnection con = new SqlConnection(@"Data Source=GEARLESS-JOE;Initial Catalog=ClientDatabase;Integrated Security=True");
            String query = "Select FirstName,UserPassword From UserList where Firstname ='" + username + "' and UserPassword ='" + password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            String output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                ViewBag.Message = "Vous êtes connecté";
            }
            else
            {
                Response.Write("Veuillez vérifier vos informations");
            }*/
        }
    }
}