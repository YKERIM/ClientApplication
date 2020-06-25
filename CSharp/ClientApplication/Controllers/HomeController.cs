using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        public List<User> user_saved = new List<User>();
        public SqlConnection con = new SqlConnection(@"Data Source=JIREN-SAMA;Initial Catalog=ClientApplication;Integrated Security=True");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authentification()
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
                user_saved.Add(user);
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
            foreach (var current_user in user_saved)
            {
                if (current_user.tokenApp == user.tokenApp)
                {
                    user.userName = current_user.userName;
                    user.password = current_user.password;
                }
            }

            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From UserList where Firstname ='" + user.userName + "' and UserPassword ='" + user.password + "' and TokenApp = '" + user.tokenApp + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                Response.Redirect("~/Home/DecryptagePage");
            }
            else
            {
                ViewBag.Message = user;
            }

            return View();
        }
    }
}