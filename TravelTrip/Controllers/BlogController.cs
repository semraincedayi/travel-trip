using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context _context=new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
           // var bloglar=_context.Blogs.ToList();
           by.Deger1 = _context.Blogs.ToList();
            by.Deger3=_context.Blogs.OrderByDescending(x=>x.Id).Take(5).ToList();
            by.Deger2 = _context.Yorumlars.OrderByDescending(x=>x.ID).Take(5).ToList();
            return View(by);
            
        }
        
        public ActionResult BlogDetails(int id)
        {
            //var blogBul = _context.Blogs.Where(x => x.Id == id).ToList();
            by.Deger1 = _context.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = _context.Yorumlars.Where(x => x.BlogId == id).ToList();
            by.Deger3 = _context.Blogs.Take(5).ToList();
            return View(by);

        }
    }
}