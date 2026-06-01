using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.Models.Class;
using static System.Net.WebRequestMethods;

namespace TravelTrip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context _context= new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            var url = Request.RawUrl;

            if (url.ToLower() == "/login/login")
            {
                return Redirect("/Login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(Admin admn)
        {
            var infos= _context.Admins.FirstOrDefault(x => x.Username == admn.Username && x.Password == admn.Password);
            if (infos != null)
            {
                FormsAuthentication.SetAuthCookie(infos.Username, false);
                Session["Kullanici"] = infos.Username.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
       

    }
}