using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;

namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            context.Blogs.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blogs = context.Blogs.Find(id);
            return View("UpdateBlog", blogs);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            var blogs = context.Blogs.Find(b.Id);
            blogs.Baslik = b.Baslik;
            blogs.Tarih = b.Tarih;
            blogs.BlogImage = b.BlogImage;
            blogs.Aciklama = b.Aciklama;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}