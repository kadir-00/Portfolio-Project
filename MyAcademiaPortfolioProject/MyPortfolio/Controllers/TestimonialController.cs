using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    
    public class TestimonialController : Controller
    {
        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();
        // GET: Testimonial
        public ActionResult Index()
        {
            var value = db.TblTestimonials.ToList();
            return View(value);
        }

        // eklem islemi yapalim
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials Testimonial)
        {
            db.TblTestimonials.Add(Testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ekleme islemi bitti


        // Silme islemi

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // silme islemi bitti

        // Guncellem Islemini Yapalim
        // Update islemi yapalim , bu da get ve post olarak yapiliyor neden
        // once verilerimi input degerelere tasimamiz gerek

        // burada sedece degerleri inputa tasidik 
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            //var value = db.TblSkills.FirstOrDefault(x => x.SkilId == id);
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials testimonial)
        {

            var value = db.TblTestimonials.Find(testimonial.TestiMoninialId);
            value.ImageUrl = testimonial.ImageUrl;
            value.Comment = testimonial.Comment;
            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.CommentDate = testimonial.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // update islemi bitti OLMADIIIIII
    }
}
