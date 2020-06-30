using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApplication.Models
{
    public class User
    {
        public string userName { get; set; }

        public string password { get; set; }

        public string tokenApp { get; set; }

        public string tokenUser { get; set; }

    }
}