using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();
        public ActionResult Index()
        {
            var value = db.TblServices.ToList();
            return View(value);
        }

        // CRUD Islemleri = Create Read Update Delete

        // ekleme islemi yapalim 

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblServices services)
        {
            db.TblServices.Add(services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // ekleme islemi bitti

        // silme islemi yapalim
        public ActionResult DeleteService(int id) 
        {
        var value = db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // silme islemi bitti

        // guncelleme islemi yapalim
        [HttpGet]
        public ActionResult UpdateService(int id) 
        { 
        var value = db.TblServices.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblServices services) 
        {
            var value = db.TblServices.Find(services.ServersId);
            value.ServersId = services.ServersId;
            value.Icon = services.Icon;
            value.Title=services.Title;
            value.Description=services.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // guncelleme islemi bitti

    }
}