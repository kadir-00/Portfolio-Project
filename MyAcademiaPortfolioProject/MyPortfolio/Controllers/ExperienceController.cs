using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Contact

        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities  ();
        public ActionResult Index()
        {
            var value = db.TblExperiences.ToList();
            return View(value);
        }

        // CRUD Islemleri = Create Read Update Delete

        // ekleme islemi yapalim 

        [HttpGet]
        public   ActionResult AddExperience() 
        { 
        return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperiences experience) 
        { 
         db.TblExperiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // ekleme islemi bitti

        // silme islemi yapalim , burada view ekleme fln yok link verecez buttona
        public ActionResult DeleteExperience(int id ) 
        {
            var value = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(value);
            db.SaveChanges ();
            return RedirectToAction("Index");
        }

        // silme islemi bitti

        // Update islemi yapalim , bu da get ve post olarak yapiliyor neden
        // once verilerimi input degerelere tasimamiz gerek


        // burada sedece degerleri inputa tasidik 
        [HttpGet]
        public ActionResult UpdateExperience(int id) 
        {
            var value = db.TblExperiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences experiences)
        {
            var value = db.TblExperiences.Find(experiences.ExperienceId);
            value.StartYear = experiences.StartYear;
            value.EndYear = experiences.EndYear;
            value.Title = experiences.Title;
            value.Description = experiences.Description;
            value.Company = experiences.Company;
            value.Location = experiences.Location;
            db.SaveChanges();
            return RedirectToAction("Index");   


        }
        // update islemi bitti 
        

    }
}