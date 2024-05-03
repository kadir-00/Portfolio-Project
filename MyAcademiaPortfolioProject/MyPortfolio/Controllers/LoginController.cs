using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    
    public class LoginController : Controller
    {
       
        // GET: Login

        MyAcademiPortfolioProjectEntities db = new MyAcademiPortfolioProjectEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmins admin)
        { // sifreli giris ekrani 
            var value = db.TblAdmins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (value != null)
            {
                // web security kutpunu ekledik , setauthcookie ile cookie olusturduk 
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["userName"] = value.UserName; // giris yapildiktan sonra o sure boyunca hafizada tutuyor
                return RedirectToAction("Index","About");

            }
            else
            { // hata olusturucaz 
                ModelState.AddModelError("", "Kullanici adi veya sifre yanlis ");
                return View();
            }
            // bunlardan sonra index'e add view yaptik partial'siz layout'suz baslibasina sayfa olacak 
        }

        // Logout islemi yaptiracaz 
        public ActionResult Logout() 
        {
        FormsAuthentication.SignOut();
            Session.Abandon(); // sessiondaki degeri kaldir babinda 
            return RedirectToAction("Index" , "Default"); // indexe atsin dedik

            // login.controller da logout methodu olusturduk bunun linkini layouta vermem lazim 
        }
    }
}