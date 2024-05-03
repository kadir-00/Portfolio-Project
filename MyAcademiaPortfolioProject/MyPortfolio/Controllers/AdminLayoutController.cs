using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        // Bu sayfayi AdminLayoutu daha kkolaya yonetmek icin actik

        // GET: AdminLayout
        public PartialViewResult AdminLayoutSideBar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutHead() 
        {
            return PartialView();
        }

    }
}