using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        public ActionResult AddProject()
        {
            // neden bunlari post'ta degilde get'te yaptik : post'ta yapmis olsaydik sayfa yuklendiginde kategorilerin ismi gelmezdi
            var categories = db.TblCategories.ToList();
            List<SelectListItem> categoryList = (from x in categories select new SelectListItem 
            {
                 Text = x.CategoryName,
                 Value = x.CategoryId.ToString()
            }).ToList();

            // 
            ViewBag.category = categoryList;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProjects project) 
        {
            db.TblProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        // Update islemi yapicaz 
        [HttpGet]
        public ActionResult UpdateProject(int id ) 
        {
            

            var categories = db.TblCategories.ToList();
            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            // 
            ViewBag.category = categoryList;
            var value = db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProjects projects) 
        {
            var value = db.TblProjects.Find(projects.ProjectId);
            value.ProjectName = projects.ProjectName;
            value.ImageUrl = projects.ImageUrl;
            value.GitHubUrl = projects.GitHubUrl;
            value.CategoryId = projects.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // silme islemini yapalim 
        public ActionResult DeleteProject(int id )
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}