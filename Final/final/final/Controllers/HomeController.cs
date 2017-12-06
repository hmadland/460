using System;
using System.Linq;
using System.Web.Mvc;
using final.Models;
using System.Net;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;


namespace final.Controllers
{
    public class HomeController : Controller
    {
        private finalContext db = new finalContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Items()
        {

            return View(db.Items.ToList());
        }

  

        //GET Items
        public ActionResult Create()
        {
            return View();
        }

        //POST Items
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID, ItemName, ItemDescription, SellerName")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Items");
            }

            return View(item);
        }


        // GET: Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }


        // GET: edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID, ItemName, ItemDescription, SellerName")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Items");
            }
            return View(item);
        }


        // GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Items");
        }


        //GET bid
        public ActionResult CreateBid()
        {
            return View();
        }

        //POST bid
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid([Bind(Include = "ItemID, BuyerName, Price, BidTime")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bid);
        }


        public JsonResult GetBids(int? id)
        {
            var results = db.Bids.Where(x => x.ItemID == id) //where GenreID matches button clicked
                                 .Select(x => new { x.Price, x.Buyer.BuyerName })
                                 .OrderBy(x => x.Price)
                                 .ToList();
            //return Json object
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}