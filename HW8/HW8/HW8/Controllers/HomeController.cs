using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.Models;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
       private HW8Model db = new HW8Model();


            public ActionResult Index()
        {
            return View();
        }


       
        public ActionResult Artists()
        {
            return View(db.Artists.ToList());
        }

        public ActionResult ArtWorks()
        {
            return View(db.ArtWorks.ToList());
        }

        public ActionResult Classifications()
        {
            return View(db.Classifications.ToList());
        }
    }
}