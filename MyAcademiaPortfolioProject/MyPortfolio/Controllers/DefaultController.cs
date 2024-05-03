using Microsoft.Ajax.Utilities;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers

{
    [AllowAnonymous] // herkes buraya erisebilir dedik Allow sayesinde 
    public class DefaultController : Controller
    {
        // GET: Default

        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial()
        {    // listelemeyi yapalim
        var value = db.TblFeatures.ToList();
        return PartialView(value); // value parantez icine yazmazsan bos deger doner o da HATA VERIIDIRIRIRI
        }

        // About kismi icin listeleme yapmak icin
        public ActionResult DefaultAboutPartial()
        {
            var value = db.TblAbout.ToList();
            return PartialView(value);
        }

        // Mesaj gonderme kismi Getli Postlu yapmamiz lazim
        [HttpGet]
        public PartialViewResult SendMessage() 
        {
        return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultServicePartial()
        {
            var value = db.TblServices.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);

        }

        public PartialViewResult DefaultProjectPartial()
        { 
            // web uygulamasi secenegi 2 tane geldi onu cozucez 
            var categories = db.TblCategories.ToList();
            ViewBag.Categories = categories;

        var value = db.TblProjects.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultExperiencePartial()
        {
            var value = db.TblExperiences.ToList();
            return PartialView(value);


        }

        public PartialViewResult DefaultTestimonialPartial()
        { 
        var deger = db.TblTestimonials.ToList();
            return PartialView(deger);
        }

        public PartialViewResult DefaultTeamPartial()
        { 
        var value = db.TblTeams.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultSocialMediaPartial() 
        {
        var value = db.TblSocialMedias.ToList();
            return PartialView(value);
        }
    }
}