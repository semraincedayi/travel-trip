using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;

namespace TravelTrip.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context _context = new Context();
        public ActionResult ContactInf()
        {
            var degerler = _context.Iletisims.ToList();
            return View(degerler);
            
        }
        
    }
}