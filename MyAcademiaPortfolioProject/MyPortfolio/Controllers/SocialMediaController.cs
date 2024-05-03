using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var deger = db.TblSocialMedias.ToList();
            return View(deger);
        }

        // ekleme islemini yaptiralim 
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        // bu buttona tiklandiginda calisacak 
        // asagidakileri kodlar bize ADO.Net'te INSERT INTO yazmamizi gerektirmeden ekledi, Entity Framework'un kolayligi
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialmedia)
        {
            db.TblSocialMedias.Add(socialmedia);
            db.SaveChanges();   // bunu yazmassan ekleme olmaz,ADO.Net'te executenonquery ye denk geliyor
            return RedirectToAction("Index");

        }
        // ekleme islemi bitti

        // silme islemi yapalim
        
        public ActionResult DeleteSocialMedia(int id) 
        {
        var value = db.TblSocialMedias.Find(id);
         db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // silme islemi bitti

        // guncelleme islemini yapalim
        // burada sedece degerleri inputa tasidik 
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            //var value = db.TblSkills.FirstOrDefault(x => x.SkilId == id);
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialmedia)
        {

            var value = db.TblSocialMedias.Find(socialmedia.SocialMediaId);
            value.SocialMediaName = socialmedia.SocialMediaName;
            value.Url = socialmedia.Url;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // update islemi bitti
    }
}