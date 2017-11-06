using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HW5.DAL;
using HW5.Models;


namespace HW5.Controllers
{
    public class FormsController : Controller
    {
        private DAL.FormContext db = new DAL.FormContext();

        // GET: Forms
        public ActionResult Index()
        {
            return View(db.Forms.ToList());
        }

        // GET: Forms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, FirstName, LastName, DOB, City, NewAddress, NewState, Zip, County")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(form);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
