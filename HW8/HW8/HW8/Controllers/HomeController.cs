using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.Models;
using System.Net;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
      private HW8Model db = new HW8Model();


        public ActionResult Index(int? id)
        {
            var genreCat = db.Genres;
            if (id != null && db.Genres.Find(id) != null)
            {
                ViewBag.ID = id;
            }
            return View(genreCat);
        }

        public ActionResult JasonResult(int? id) 
        {
                var results = db.Genres.Where(x => x.GenreID == id) //where GenreID matches button clicked
                                 .Select(x => x.Classifications)    //selected from Classifications
                                 .First()
                                 //from virtual ArtWork1 get artist and title
                                 .Select(x => new { x.ArtWork1.Artist, x.ArtWork1.Title }) 
                                 .OrderBy(x => x.Title)
                                 .ToList();
                //return Json object
                return Json(results, JsonRequestBehavior.AllowGet);
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

        //POST Artists
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

        // GET: Artist/Details
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
        public ActionResult Edit([Bind(Include = "ArtistID, FullName, DOB, BirthCity, BirthCountry")] Artist artist)
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

        // POST: Artist/Delete/5
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

    //PastDateAttribute so DOB can't be in future
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            DateTime? dateValue = value as DateTime?;
            if (dateValue != null)
            {
                if (dateValue.Value.Date > DateTime.UtcNow.Date)
                {
                    return new ValidationResult("Not a valid Date");
                }
            }
            return ValidationResult.Success;
        }
    }
}