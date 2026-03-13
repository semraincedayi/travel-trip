using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;

namespace TravelTrip.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Blogs.OrderByDescending(x =>x.Id).Take(4).ToList();
            return View(degerler);
        }
        public ActionResult About()
        {

            return View();
        }
        public PartialViewResult Partial1()
        {
            var degerler= context.Blogs.OrderByDescending(x => x.Tarih).Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.Tarih).Take(10).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial3()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.Id).Take(6).ToList();
            return PartialView(degerler);
        }
    }

}