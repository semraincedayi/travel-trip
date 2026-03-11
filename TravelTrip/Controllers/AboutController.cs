using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;

namespace TravelTrip.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context _context=new Context();
        public ActionResult Index()
        {
            var degerler=_context.Hakkimizdas.ToList();
            return View(degerler);
        }
    }
}