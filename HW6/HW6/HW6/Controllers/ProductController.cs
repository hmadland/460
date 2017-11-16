using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HW6.Controllers
{
    public class ProductController : Controller
    {
        private Models.Model1 db = new Models.Model1();
        
        public ActionResult Index(int? id)
        {
            var pCategories = db.ProductCategories;
       //find out if ProductCategory was selected
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.ID = id;
            }

            return View(pCategories);
        }

        [HttpGet]
        public ActionResult Review(int? id)
        {
            int productid = id ?? -1;
            // if id was not given
            if (productid == -1) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var productTitle = db.Products.Find(productid);

            // if product does not exist
            if (productTitle == null) 
                return HttpNotFound();

            // make new Review for this Product and send to View
            Models.ProductReview review = db.ProductReviews.Create();
            review.Product = productTitle;
            review.ProductID = productid;
             review.ReviewDate = DateTime.Now;
             review.ModifiedDate = review.ReviewDate;

            //review.ReviewDate = review.ModifiedDate = DateTime.Now;
           

            return View(review);
        }

        [HttpPost]
        public ActionResult Review(Models.ProductReview review)
        {
            // if valid, add to db and redirect back to Product page
            if (ModelState.IsValid)
            {
                db.ProductReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("IndividualProduct", new { id = review.ProductID });
            }
            // return prepopulated model back to user if not valid
            review.Product = db.Products.Find(review.ProductID);
            return View(review);
        }


        public ActionResult ViewReviews(int? id)
        {
            var rev = db.ProductReviews;
          
            return View(rev);
        }


        public ActionResult MultiProducts(int? id, int? page = 1)
        {
            if (id == null || db.ProductSubcategories.Find(id) == null)
                // if subcategory doens't exists 
                return RedirectToAction("Index"); 

            var products = db.ProductSubcategories.Find(id).Products.ToList();
            // num of items per page
            int pageSize = 8;
            // num of pages
            double numOfPages = Math.Ceiling((double)products.Count / pageSize); 

           int pageNumber = page ?? 1;
          
            ViewBag.NumberOfPages = numOfPages;

            // get items based off page number
            var productPaged = products.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return View(productPaged);
        }

        public ActionResult IndividualProduct(int? id)
        {
            // if product id wasn't given
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            // if product does not exist
            if (product == null) 
                return HttpNotFound();

            // find the unit of measurement for product size if it exists
            var sizeUnit = product.SizeUnitMeasureCode;
            ViewBag.SizeUnit = sizeUnit == null ? "N/A" : product.SizeUnitMeasureCode.ToLower();

            // find the unit of measurement for product weight if it exists
            var weightUnit = product.WeightUnitMeasureCode;
            ViewBag.WeightUnit = weightUnit == null ? "N/A" : product.WeightUnitMeasureCode.ToLower();
            return View(product);
        }


        public ActionResult ProductPhoto(int? id, bool? photo)
        {
            int ID;
            if (int.TryParse(id.ToString(), out ID)) { }
            var img = db.ProductProductPhotoes.Where(product => product.ProductID == ID).FirstOrDefault().ProductPhoto.LargePhoto;
            return File(img, "image/gif");
        }
    }
}