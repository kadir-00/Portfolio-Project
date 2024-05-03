using MyPortfolio.Models;
using MyPortfolio.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize] // Authorize islemi

    [SessionTimeOut]
    public class AboutController : Controller
    {
        // GET: About 
        // db nesnesi turetmis olduk
        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities(); 

        public ActionResult Index()
        {
           // ViewBag.user = Session["userName"]; // bunu yapmamizin sebibi giris yapan kisinin ismini
                                                // sag uste layout'a yazdirdik

            // asagida dedikki TblAbout'taki degerleri listele bunlari da values degerine ata dedik
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        { 
        return View();
        }

        // bu buttona tiklandiginda calisacak 
        // asagidakileri kodlar bize ADO.Net'te INSERT INTO yazmamizi gerektirmeden ekledi, Entity Framework'un kolayligi
        [HttpPost]
        public ActionResult AddAbout(TblAbout about)
        {
            db.TblAbout.Add(about);
            db.SaveChanges();   // bunu yazmassan ekleme olmaz,ADO.Net'te executenonquery ye denk geliyor
            return View();
        
        }

        // SILME Islemi yaptiricaz
        public ActionResult DeleteAbout(int id) 
        {
          var about =  db.TblAbout.Find(id);
            db.TblAbout.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index"); // beni tekrara index'e gonder dedik 
            // yukardaki indexe go to view yapop gelen sayfada sil linkine bu sayfaya yonlendirdik
        }

        // GUNCELLEME yapicaz,verileri input degerine tasimam gerek
        [HttpGet]
        public ActionResult UpdateAbout (int id) 
        {
            var about = db.TblAbout.Find(id);
            return View(about);
        }
        // BURADA buttona basildiginda ne yapmasi gerektigini soyledik
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout about)
        {
            var value = db.TblAbout.Find(about.AboutId);
            value.ImageUrl = about.ImageUrl;
            value.Title = about.Title;
            value.Description = about.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}