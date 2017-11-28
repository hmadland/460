using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.Models;
using System.Net;
using System.Data.Entity;

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

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //get artist details
        public ActionResult etails(int? id)
        {
            // if product id wasn't given
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var artist = db.Artists.Find(id);
            //var work = db.ArtWorks.Find( id);
          
            ViewBag.FullName = artist.FullName;
            ViewBag.DOB = artist.DOB;
            ViewBag.city = artist.BirthCity;
            ViewBag.counry = artist.BirthCountry;
            //ViewBag.work = work.ArtistID == id;
            var Artwork = db.ArtWorks.Where(c =>c.ArtistID ==id).Select(c => c.Title);
            //ViewBag.Artwork = work;
            return View();
        }


        // GET: Artists/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,FullName,DOB,BirthCity, BirthCountry ")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }


        // GET: Artists/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Artists");
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