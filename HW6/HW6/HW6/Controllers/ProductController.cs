
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HW6.Controllers
{
    public class ProductController : Controller
    {
        private  Model1 db= new Model1();
        // GET: Product
        public ActionResult Index(int? id)
        {
            var stuff = db.ProductCategories;
            //determine if a ProductCategory was selected
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.ID = id;
            }

            return View(stuff);
        }
    }
}