using SklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public string Create()
        {
            IdentityManager im = new IdentityManager();

            im.CreateRole("Admin");
            im.CreateRole("User");

            return "OK";
        }

        public string AddToRole()
        {
            Models.IdentityManager im = new IdentityManager();

            //im.AddUserToRoleByUsername("violetta.rushnitskaya@gmail.com", "Admin");
            im.AddUserToRoleByUsername("admin@gmail.com", "Admin");

            return "OK";
        }
    }
}