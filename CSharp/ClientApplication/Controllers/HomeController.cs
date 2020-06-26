using ClientApplication.Models;
using ClientWCF;
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
        public SqlConnection con = new SqlConnection(@"Data Source=JIREN-SAMA;Initial Catalog=ClientApplication;Integrated Security=True");
        ServiceClient client = new ServiceClient();

        public ActionResult Index()
        {
   //         ViewBag.Message = client.Message();
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
            ViewBag.Message = client.TokenApp(user.tokenApp);

            return View();
        }
    }
}