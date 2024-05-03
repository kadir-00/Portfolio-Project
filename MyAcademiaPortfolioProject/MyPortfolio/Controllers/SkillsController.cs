using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyPortfolio.Controllers
{
    public class SkillsController : Controller

        
    {
        // GET: Skills

        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblSkills.ToList();
            return View(value);
        }

        // eklem islemi yapalim

        [HttpGet]
        public ActionResult AddSkills() 
        { 
        return View();
        }

        [HttpPost]
        public ActionResult AddSkills(TblSkills skill ) 
        {
        db.TblSkills.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ekleme islemi bitti

        // Silme islemini yapalim 

        public ActionResult DeleteSkills(int id)  
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }
        // silme islemi bitti

        // Guncellem Islemini Yapalim
        // Update islemi yapalim , bu da get ve post olarak yapiliyor neden
        // once verilerimi input degerelere tasimamiz gerek

        // burada sedece degerleri inputa tasidik 
        [HttpGet]
        public ActionResult UpdateSkills(int id)
        {
            //var value = db.TblSkills.FirstOrDefault(x => x.SkilId == id);
            var value = db.TblSkills.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkills(TblSkills skills)
        {

            var value = db.TblSkills.Find(skills.SkilId);
            value.SkillName=skills.SkillName;
            value.Value=skills.Value;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // update islemi bitti OLMADIIIIII
    }
}