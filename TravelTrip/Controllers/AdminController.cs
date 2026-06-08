using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Class;

namespace TravelTrip.Controllers
{
    [Authorize]
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
        public ActionResult NewBlog(Blog p, HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null && FileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(FileUpload.FileName);
                var filepath = Server.MapPath("~/Images/");
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                var path = Path.Combine(filepath, fileName);
                FileUpload.SaveAs(path);
                p.BlogImage = "/Images/" + fileName;
            }
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
        public ActionResult UpdateBlog(Blog b, HttpPostedFileBase FileUpload)
        {
            var blogs = context.Blogs.Find(b.Id);
            blogs.Baslik = b.Baslik;
            blogs.Tarih = b.Tarih;
            if (FileUpload != null && FileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(FileUpload.FileName);
                var filepath = Server.MapPath("~/Images/");
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                var path = Path.Combine(filepath, fileName);
                FileUpload.SaveAs(path);
                blogs.BlogImage = "/Images/" + fileName;
            }
            blogs.Aciklama = b.Aciklama;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CommentsList()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);  
        }
        public ActionResult DeleteComment(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(yorum);
            context.SaveChanges();
            return RedirectToAction("CommentsList");

        }
        [HttpGet]
        public ActionResult UpdateComment(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            return View("UpdateComment", yorum);
        }
        [HttpPost]
        public ActionResult UpdateComment(Yorumlar y)
        {
            var yorum = context.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("CommentsList");
        }
    }
}