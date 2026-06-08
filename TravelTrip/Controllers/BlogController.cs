using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;
using TravelTrip.ViewModels;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context _context = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index(int page=1)
        {
            int atlanacakveri = 5;
            by.DegerBlog = _context.Blogs.Select(x => new BlogSumViewModel 
           { 
               Id = x.Id, 
               Baslik = x.Baslik, 
               BlogImage=x.BlogImage,
               KisaAciklama =x.Aciklama != null && x.Aciklama.Length >= 150 ? x.Aciklama.Substring(0, 150): x.Aciklama  
           }).OrderByDescending(x => x.Id).Skip((page - 1) * atlanacakveri).Take(atlanacakveri).ToList();
            by.Deger3=_context.Blogs.OrderByDescending(x=>x.Id).Take(5).ToList();
            by.Deger2 = _context.Yorumlars.OrderByDescending(x=>x.ID).Take(5).ToList();
            int toplamveri = _context.Blogs.Count();
            double pagenumber = (double)toplamveri / atlanacakveri;
            pagenumber=Math.Ceiling(pagenumber);
            ViewBag.pagenumber = pagenumber;
            ViewBag.CurrentPage = page;
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
        [HttpGet]
        public PartialViewResult PostComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PostComment(Yorumlar y)
        {
            _context.Yorumlars.Add(y);
            _context.SaveChanges();
            return PartialView();
        }
         
    }
}