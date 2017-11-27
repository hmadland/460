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

       //list Artists
        public ActionResult Artists()
        {
            return View(db.Artists.ToList());
        }

        //GET Artists
        public ActionResult Create()
        {
            return View();
        }

        //POST artists
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID, FullName, DOB, BirthCity, BirthCountry")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artists");
            }

            return View(artist);
        }


        //list Artworks
        public ActionResult ArtWorks()
        {
            return View(db.ArtWorks.ToList());
        }

        //list Classifications
        public ActionResult Classifications()
        {
            return View(db.Classifications.ToList());
        }
    }
}