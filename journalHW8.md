---
title: Homework 8
layout: default
---
## Homework 8
For this assignment we were asked to create a complex web application from scratch that included a database, CRUD functionality and some AJAX.
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8.html).

## Step One:
First off I created a new MVC app and HW8feature branch. After getting the project on a new branch I added a database and did a rough sketch of the ER diagram for the tables.
![](img/HW8ER.PNG?raw=true)

Once I had a basic idea of what the tables should contain I built them, used the seed data provided and saved the query in my UpSQL. I did have to change the DOB datatype to Date instead of datetime because it didn't like the years being so far in the past.

```bash
alter table dbo.Artists
Drob DOB

Alter table dbo.Artists
add DOB Date
```
UpSQL
```bash
CREATE TABLE dbo.Artists
(
ArtistID INT IDENTITY (1,1) NOT NULL,
FullName	NVARCHAR(128) NOT NULL,
DOB			Date NOT NULL,
BirthCity	NVARCHAR(128) NOT NULL,
BirthCountry NVARCHAR(128) NOT NULL
CONSTRAINT[PK_dbo.Artists] PRIMARY KEY CLUSTERED (ArtistID ASC)
);

CREATE TABLE dbo.ArtWorks
(
ArtWorkID INT IDENTITY (1,1) NOT NULL,
Title	NVARCHAR(128) NOT NULL,
Artist	NVARCHAR(128) NOT NULL,
ArtistID INT,
CONSTRAINT[PK_dbo.ArtWorks] PRIMARY KEY CLUSTERED (ArtWorkID ASC),
CONSTRAINT FK_ArtistID FOREIGN KEY (ArtistID)
REFERENCES Artists(ArtistID)
);

CREATE TABLE dbo.Genres
(
GenreID INT IDENTITY (1,1) NOT NULL,
GName	NVARCHAR(128) NOT NULL,
CONSTRAINT[PK_dbo.Genres] PRIMARY KEY CLUSTERED (GenreID ASC),
);

CREATE TABLE dbo.Classifications
(
ClassID INT IDENTITY (1,1) NOT NULL,
Artwork	NVARCHAR(128) NOT NULL,
Genre	NVARCHAR(128) NOT NULL,
ArtWorkID INT,
GenreID INT,
CONSTRAINT[PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassID ASC),
CONSTRAINT FK_ArtWorkID FOREIGN KEY (ArtWorkID)
REFERENCES ArtWorks(ArtWorkID),
CONSTRAINT FK_GenreID FOREIGN KEY (GenreID)
REFERENCES Genres(GenreID)
);
```
## Step two
Next I added a menu item to the shared layout so the user could select one of the three Views: Artists, ArtWorks, and Classifications.
```bash
<div class="navbar-collapse collapse">
              <ul class="nav navbar-nav">
                                    //string name, viewname, controllername
                  <li>@Html.ActionLink("Home", "Index", "Home")</li>
                  <li>@Html.ActionLink("Artists", "Artists", "Home")</li>
                  <li>@Html.ActionLink("Artworks", "Artworks", "Home")</li>
                  <li>@Html.ActionLink("Classifications", "Classifications", "Home")</li>
              </ul>
</div>
```
Before consturucting the Views I auto generated the models by
models ->
add ->
ADO.Net Entity Data Model ->
Code first from DB (give it a name)->
Tables ->
Finish
(In controller add "private (name) db= new (name)();" or private HW8Model db = new HW8Model();)

After that I constructed the views so that each showed all the information from their respective tables.
Artist View:
Link to all other Views [here](https://github.com/hmadland/460/tree/master/HW8/HW8/HW8/Views/Home).
```bash
@model IEnumerable<HW8.Models.Artist>
@{
    ViewBag.Title = "Artists";
}
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.FullName)
        </th>
    </tr>
    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.FullName)
            </td>

            <!---links to details, edit, and delete pages and controller-->
            <td>
            @Html.ActionLink("Details", "Details", new { id = item.ArtistID })
            </td>
            <td>
            @Html.ActionLink("Edit", "Edit", new { id = item.ArtistID })
            </td>
            <td>
            @Html.ActionLink("Delete", "Delete", new { id = item.ArtistID })
            </td>
        </tr>
    }
</table>
<div class="btn-group">
    @Html.ActionLink("Add an Artist", "Create", "Home", null, new { @class = "btn btn-lg" })
</div>

```
Once the basic views were created I committed to my feature branch and pushed to github.

## Step three
Next I implement CRUD functionality for Artists.
Artist Index/List page (already shown above)
On my Artist View I added links to
an add new artist page (Create),
```bash
@model HW8.Models.Artist
@{
    ViewBag.Title = "Create";
}
<h2>Create</h2>

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })

        <div class="form-group">
            @Html.LabelFor(model => model.FullName, new { htmlAttributes = new { @class = "control-label" } })
            @Html.EditorFor(model => model.FullName, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.FullName, "", new { @class = "text-danger" })
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.DOB, new { htmlAttributes = new { @class = "control-label" } })
            @Html.EditorFor(model => model.DOB, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.DOB, "", new { @class = "text-danger" })
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.BirthCity, new { htmlAttributes = new { @class = "control-label" } })
            @Html.EditorFor(model => model.BirthCity, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.BirthCity, "", new { @class = "text-danger" })
        </div>
        <div class="form-group">
            @Html.LabelFor(model => model.BirthCountry, new { htmlAttributes = new { @class = "control-label" } })
            @Html.EditorFor(model => model.BirthCountry, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.BirthCountry, "", new { @class = "text-danger" })
        </div>
        <div class="form-group">
            <div>
                <input type="submit" value="Create" class="btn btn-lg" />
            </div>
        </div>
    </div>
}
<div>
    @Html.ActionLink("Back", "Artists")
</div>

```
an artist Details page (Read)
```bash
@model HW8.Models.Artist
@{
    ViewBag.Title = "Details";
}
<div>
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.FullName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.FullName)
        </dd>
        <dt>
            @Html.DisplayNameFor(model => model.DOB)
        </dt>
        <dd>
            @Html.DisplayFor(model => model.DOB)
        </dd>
        <dt>
            @Html.DisplayNameFor(model => model.BirthCity)
        </dt>
        <dd>
            @Html.DisplayFor(model => model.BirthCity)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthCountry)
        </dt>
        <dd>
            @Html.DisplayFor(model => model.BirthCountry)
        </dd>

    </dl>
</div>
<div>
    @Html.ActionLink("Back", "Artists")
</div>

```
an artists Edit page (Update)
```bash
@model HW8.Models.Artist
@{
    ViewBag.Title = "Edit";
}
<h3>Are you sure you want to edit this artist?</h3>
@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()

        <div class="form-horizontal">

            @Html.ValidationSummary(true, "", new { @class = "text-danger" })
            @Html.HiddenFor(model => model.ArtistID)

            <div class="form-group">
                @Html.LabelFor(model => model.FullName, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(model => model.FullName, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.FullName, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.DOB, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @ViewBag.error
                    @Html.EditorFor(model => model.DOB, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.DOB, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.BirthCity, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(model => model.BirthCity, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.BirthCity, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.BirthCountry, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(model => model.BirthCountry, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.BirthCountry, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-lg" />
                </div>
            </div>
        </div>
        }
        <div>
            @Html.ActionLink("Back", "Artists")
        </div>
```
and an artist Delete page (Delete)
```bash
@model HW8.Models.Artist
@{
    ViewBag.Title = "Delete";
}
<h3>Are you sure you want to delete this artist?</h3>
<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.FullName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.FullName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.DOB)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.DOB)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthCity)
        </dt>
        <dd>
            @Html.DisplayFor(model => model.BirthCity)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthCountry)
        </dt>
        <dd>
            @Html.DisplayFor(model => model.BirthCountry)
        </dd>

    </dl>

    @using (Html.BeginForm())
    {
        @Html.AntiForgeryToken()
        <div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-lg" />
        </div>
        <br/>
        <div>@Html.ActionLink("Back", "Artists")</div>
    }
</div>
```
For all of these I found the examples in the class [repo](https://bitbucket.org/morses/seniorproject_2017-18/src/0c5668155762a229568a54c076669089db727b72/mvc_examples/Example2/Example2/Views/Users/?at=example2-withdb) very helpful

## Step four
Next I added the Genre buttons to the home page with a Razor foreach loop
```bash
@foreach (var genre in Model.ToList())
  {
      <input class="btn btn-default" type="button" value=@genre.GName onclick="genreClicked('@genre.GenreID')"/>
  }
```
Ajax to get the title and artist name.
```bash
function buttonClicked(gid) {
    $('#results').empty();
    $.ajax({
        type: "POST",
        url: "/Home/JasonResult/",
        data: {id:gid}, //define id as gid to use in controller
        dataType: "json",
        success: function (data) {
            $.each(data, function (i, item) {
                $("#results").append("<li>" + "<strong>" + item["Artist"] + ": " + "</strong>" + item["Title"] + "</li>");  
            });
        }
    })
};
```
HomeController
```bash
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

```
Finished pages
![](img/HW8ajax1.PNG?raw=true)

![](img/HW8ajax2.PNG?raw=true)
