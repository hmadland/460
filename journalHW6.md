---
title: Homework 6
layout: default
---
## Homework 6
For assignment 6 we were asked to built an application that used an existing database and use LINQ to access and present information from the database. The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW6.html).

##Step one
First off, I got the AdventureWorks2014.bak file from the link in the HW6 directions. Once the .bak file was restored and the database was connected to my HW6 project I auto generated the data models and the database context. To do this I simply right-clicked on the models folder, and selected Add -> New Item. From there a window popped up and I selected Data and then ADO.NET Entity Data Model this is also were you name the Data Entity Model which is also the name the context class takes too. I wound up doing this step a little too fast and named it Model1 by mistake, but it still functions even with a stupid name. After this step I then selected Code First From Database so I could work from AdventureWorks2014 after that it was simply a matter of selecting the tables I wanted to use.

##Feature one
Feature one asked us to allow a user to brows products within AdventureWorks2014.
For this I made an Index view with a nav bar listing the different product categories if a user clicked a category a list of subcategories would drop down.

```bash
@model IEnumerable<HW6.Models.ProductCategory>
@{
    ViewBag.Title = "Index";
}

<!--Background image-->
 <body background="/Content/img/forest.JPG">
    <div>
            <nav class="navbar navbar-inverse ">
            <div class="container-fluid">
                <div class="navbar-header">
                    <div>
                        <h2 style="color:white; padding-left:10px">AdventureWorks</h2>

                        <ul class="nav navbar-nav" style="padding-bottom:10px;">
                            @foreach (var product in Model.ToList())
                            {
                                @Html.ActionLink(product.Name, "Index/" + product.ProductCategoryID, new { controller = "Product" }, new { @class = "btn-lg" });
                            }
                        </ul>
                    </div>
                </div>
            </div>
        </nav>

        <div class="list-group; borderless" style="background-color:dimgray">
            <!-- If product category was selected make list of links for Subcategories -->
            @if (ViewBag.ID != null)
            {
                <!--Category selected -->
                <h2 style="color:white; padding-left:10px">@Model.Where(p => p.ProductCategoryID == ViewBag.ID).FirstOrDefault().Name</h2>

                <ul class="list-group">
                    @foreach (var item in Model.Where(p => p.ProductCategoryID == ViewBag.ID).Select(p => p.ProductSubcategories).ToList().FirstOrDefault())
                {
                        <li class="list-group-item" style="background-color:#222222; border-color: #080808;">
                            @Html.ActionLink(item.Name, "MultiProducts/" + item.ProductSubcategoryID, new { controller = "Product" }, new { @class = "btn-lg" })
                        </li>
                    }
                </ul>
            }
        </div>
    </div>
</body>
```
In my controller I accessed the db like this,
```bash
namespace HW6.Controllers
{
    public class ProductController : Controller
    {
        private Models.Model1 db = new Models.Model1();
```
and my Index page accessed the product categories as shown below.

```bash
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
```
Once a sub category was selected users would be taken to my MultiProducts View which showed them pages of products in a "col-md-3" format.
Users could navigate the pages via the page links made with bootstrap's pagination class. Users could then select an individual product by clicking on the products name which was accessed with @Html.ActionLink(product.Name, "IndividualProduct", new { id = product.ProductID }). Which took them to the IndividualProduct View.

```bash
@model IEnumerable<HW6.Models.Product>
@{
    ViewBag.Title = "MultiProducts";
}

<!--Background image-->
<body background="/Content/img/forest.JPG">    
    <div class="row" style="background-color:#222222;border-color : #080808;">

        <center><h2 style="color:white"><span ><strong> @Html.DisplayFor(modelItem => modelItem.FirstOrDefault().ProductSubcategory.Name)</strong></span></h2></center>

        <h4>
            <!-- Link back to Home  -->
            <span style="padding-left:10px">@Html.ActionLink("Home", "Index", "Product") </span> >
        </h4>

        <!-- Display image, name, product number, and price  -->
        @foreach (var product in Model)
        {
            <center>
                <div class="col-md-3">
                    <div>
                        <img src="@Url.Action("ProductPhoto", "Product", new { ID = product.ProductID, photo = true })" />
                    </div>
                    <div>
                        <!-- Product name links to product's page -->
                        <h4><strong>@Html.ActionLink(product.Name, "IndividualProduct", new { id = product.ProductID })</strong></h4>
                    </div>

                    <div style="padding-bottom:10px">
                        <h4 style="color:white"> <strong>$@Html.DisplayFor(modelItem => product.ListPrice)</strong></h4>
                    </div>
                </div>
            </center>
        }
    </div>
    <br />
    <!-- Make page links for number of pages in subcategory -->
    <div>
        <ul class="pagination pagination-lg">
            @for (int i = 1; i <= ViewBag.NumberofPages; ++i)
            {
                <li >@Html.ActionLink(i.ToString(), "MultiProducts", new { id = Model.FirstOrDefault().ProductSubcategoryID, page = i })</li>
            }
        </ul>
    </div>
</body>
```
Controller method
```bash
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
```

My IndividualProduct View showed users the product image, along with details such as color, size, weight, price, and product number.
It also gave users an option to write an review or view past reviews of the product.

```bash

@model HW6.Models.Product
@{
    ViewBag.Title = "IndividualProduct";
}

<!--background image-->
<body background="/Content/img/forest.JPG">

    <div class="row col-md-12" style="background-color:#222222; padding-bottom:20px;">

            <!-- Link back to subcategory -->
            <h4>@Html.ActionLink(Model.ProductSubcategory.Name, "MultiProducts/" + Model.ProductSubcategoryID)</h4>
        <h4>
            <span style="color:white">@Html.DisplayFor(model => model.ProductModel.Name)</span>
        </h4>
        <hr />
        <!-- Display image  -->
        <div class="row col-md-8">
            <div class="col-md-3">
                <img src="@Url.Action("ProductPhoto", "Product", new { ID = Model.ProductID, photo = true })" />
            </div>

   <!-- Display  product info-->
    <dl class="dl-horizontal col-md-5" style="color:white" >
        <dt>
            Model #:
        </dt>

        <dd >
            @Html.DisplayFor(model => model.ProductNumber)
        </dd>

        <dt>
           Color:
        </dt>

        <dd>
            @Html.DisplayFor(model => model.Color)
        </dd>

        <dt>
            Price:
        </dt>

        <dd>
            $@Html.DisplayFor(model => model.ListPrice)
        </dd>

        <dt>
            Size:
        </dt>

        <dd>
            <span>@Html.DisplayFor(model => model.Size)</span>
            <span> @ViewBag.SizeUnit</span>
        </dd>

        <dt>
            Weight:
        </dt>

        <dd>
            <span>@Html.DisplayFor(model => model.Weight)</span> @ViewBag.WeightUnit<span></span>
        </dd>
    </dl>
</div>

        <div class="col-lg-3">
            <div>
                <h4>@Html.ActionLink("Review", "Review/" + Model.ProductID)</h4>
            </div>
            <div>
                <h4>@Html.ActionLink("See all Reviews", "ViewReviews/" + Model.ProductID)</h4>
            </div>
        </div>


    </div>
</body>
```
The controller method for IndividualProduct was this
```bash
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
```

## Feature two
Feature two asked for a review option which would allow users to both review and view past reviews of a product.
On my IndividualProduct View I had two links one to the Review View, which let users give their own review of a product and a link
to ViewReviews View.
My Review View consisted of a form allowing users to enter their name, email, rating, and leave there comments as well as take not of the date.
The date gave me issues for a very long time. I kept getting the error
"conversion of datetime2 data type to a datetime data type results in out-of-range value"
It took me hours to realize I wasn't setting ModifiedDate correctly so it was using the DateTime defualt which is incompativle with SQLDateTime.
```bash
@model HW6.Models.ProductReview

@{
    ViewBag.Title = "Review";
}

<!--Background image-->
<body background="/Content/img/forest.JPG">
    <div class="row" style="background-color:#222222;border-color : #080808;">

        <h2 style="color:white; padding-left:10px"> Review @Html.ActionLink(Model.Product.Name, "IndividualProduct", new { id = Model.ProductID })</h2>

        @using (Html.BeginForm())
        {
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(true, "", new { @class = "text-danger" })

            @Html.HiddenFor(model => model.ProductID, new { htmlAttributes = new { @class = "form-control" } })

            <div class="form">

                <div class="form-group">
                    <div class="col-md-10">
                        <label style="color:white">Name</label>
                        @Html.EditorFor(model => model.ReviewerName, new { htmlAttributes = new { @class = "form-control", @maxlength = "50", @placeholder = "" } })
                        @Html.ValidationMessageFor(model => model.ReviewerName, "", new { @class = "text-danger" })
                    </div>
                </div>

                @Html.HiddenFor(model => model.ReviewDate, new { htmlAttributes = new { @class = "form-control" } })

                <div class="form-group">
                    <div class="col-md-10">
                        <label style="color:white">Email</label>
                        @Html.EditorFor(model => model.EmailAddress, new { htmlAttributes = new { @class = "form-control", @placeholder = "" } })
                        @Html.ValidationMessageFor(model => model.EmailAddress, "", new { @class = "text-danger" })
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-10">
                        <label style="color:white">Rating</label>
                        @Html.EditorFor(model => model.Rating, new { htmlAttributes = new { @class = "form-control", @min = "1", @max = "5", @maxlength = "1", @Value = "" } })
                        @Html.ValidationMessageFor(model => model.Rating, "", new { @class = "text-danger" })
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-10">
                        <label style="color:white">Comments</label>
                        @Html.EditorFor(model => model.Comments, new { htmlAttributes = new { @class = "form-control" } })
                        @Html.ValidationMessageFor(model => model.Comments, "", new { @class = "text-danger" })
                    </div>
                </div>

                        @Html.HiddenFor(model => model.ModifiedDate, new { htmlAttributes = new { @class = "form-control" } })

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10" style="padding-bottom:10px">
                        <br />
                        <input type="submit" value="Submit" class="btn btn-default" />
                    </div>
                </div>
            </div>
        }
    </div>
</body>
```
controller methods for Review
```bash
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
```
The ViewReviews View was essentially the same as the DMV change form View in HW5 so it was fairly simple to implement.
```bash
@model IEnumerable<HW6.Models.ProductReview>

    @{
        ViewBag.Title = "ViewReviews";
    }

    <!--background image-->
    <body background="/Content/img/forest.JPG">

        <div class="row col-md-12" style="background-color:#222222; padding-bottom:20px;">

            <table class="table" style="color:white">
                <tr>
                    <th>
                        @Html.DisplayNameFor(model => model.ReviewerName)
                    </th>
                    <th>
                        @Html.DisplayNameFor(model => model.Rating)
                    </th>
                    <th>
                        @Html.DisplayNameFor(model => model.Comments)
                    </th>
                    <th>
                        @Html.DisplayNameFor(model => model.ReviewDate)
                    </th>
                    <th></th>
                </tr>

                @foreach (var item in Model)
            {
                    <tr>
                        <td>
                            @Html.DisplayFor(modelItem => item.ReviewerName)
                        </td>
                        <td>
                            @Html.DisplayFor(modelItem => item.Rating)
                        </td>
                        <td>
                            @Html.DisplayFor(modelItem => item.Comments)
                        </td>
                        <th>
                            @Html.DisplayFor(modelItem => item.ReviewDate)
                        </th>
                    </tr>
                }

            </table>
        </div>
    </body>
```
controller method for ViewReviews
```bash
public ActionResult ViewReviews(int? id)
      {
          var rev = db.ProductReviews;

          return View(rev);
      }
```
## Images
I also made a controller method to allow for images in the application
```bash
public ActionResult ProductPhoto(int? id, bool? photo)
        {
            int ID;
            if (int.TryParse(id.ToString(), out ID)) { }
            var img = db.ProductProductPhotoes.Where(product => product.ProductID == ID).FirstOrDefault().ProductPhoto.LargePhoto;
            return File(img, "image/gif");
        }
```

##Site examples
The home page
![](img/HW6Index.PNG?raw=true)

The subcategories
![](img/HW6Sub.PNG?raw=true)

The products within chosen subcategory
![](img/HW6Multi.PNG?raw=true)

Individual product page
![](img/HW6Individual.PNG?raw=true)

Review form
![](img/HW6Review.PNG?raw=true)

View Reviews
![](img/HW6ViewReview.PNG?raw=true)

Review added by review form
![](img/HW6add.PNG?raw=true)
