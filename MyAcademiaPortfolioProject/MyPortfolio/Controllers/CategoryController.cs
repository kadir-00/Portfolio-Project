using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        MyAcademiPortfolioProjectEntities DB = new MyAcademiPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = DB.TblCategories.ToList();
            return View(values);
        }

        // ekleme islemi yapalim 
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategories categories)
        {
            DB.TblCategories.Add(categories);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        // SILME ISLEMI YAPALIM

        public ActionResult DeleteCategory(int id) 
        { 
        var category = DB.TblCategories.Find(id);
        DB.TblCategories.Remove(category);
        DB.SaveChanges();
            return RedirectToAction("Index");
        }

        // guncelleme

        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            var value = DB.TblCategories.FirstOrDefault(x => x.CategoryId == id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategories category)
        {
            var value = DB.TblCategories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

    } 
     }