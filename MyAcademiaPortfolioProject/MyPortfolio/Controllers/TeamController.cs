using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();
        // GET: Team
        public ActionResult Index()
        {
            var values = db.TblTeams.ToList();
            return View(values);
        }

        // ekleme islemini yaptiralim 
        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        // bu buttona tiklandiginda calisacak 
        // asagidakileri kodlar bize ADO.Net'te INSERT INTO yazmamizi gerektirmeden ekledi, Entity Framework'un kolayligi
        [HttpPost]
        public ActionResult AddTeam(TblTeams team)
        {
            db.TblTeams.Add(team);
            db.SaveChanges();   // bunu yazmassan ekleme olmaz,ADO.Net'te executenonquery ye denk geliyor
            return RedirectToAction("Index");

        }
        // ekleme islemi bitti 

        // Silme islemi yapalim 
        public ActionResult DeleteTeam(int id) 
        {
            var value = db.TblTeams.Find(id);
            db.TblTeams.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // silme islemi bittti 

        // guncelleme islemini yapalim
        // burada sedece degerleri inputa tasidik 
        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            //var value = db.TblSkills.FirstOrDefault(x => x.SkilId == id);
            var value = db.TblTeams.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTeam(TblTeams team)
        {

            var value = db.TblTeams.Find(team.TeamId);
            value.ImageUrl = team.ImageUrl;
            value.NameSurname = team.NameSurname;
            value.Title = team.Title;
            value.Description = team.Description;
            value.TwitterUrl = team.TwitterUrl;
            value.FacebookUrl = team.FacebookUrl;
            value.LinkedinUrl = team.LinkedinUrl;
            value.InstagramUrl = team.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // update islemi bitti OLMADIIIIII
    }
}
