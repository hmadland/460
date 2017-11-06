---
title: Homework 5
layout: default
---
## Homework 5
The fifth assignment asked us to create a simple MVC project that used a database. We were tasked with making a simple DMV change of address form that would update our local DB.
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5.html).

## Database
First off I created a database using LocalDB and wrote the up.sql and down.sql scripts.
It took me an annoyingly long amount of time to figure out why I wasn't able to view my entries, but it turned out I was running the up.sql on master and not my local .mdf file.

up.sql creates the table and inserts five entries.
```bash
-- Form table
CREATE TABLE dbo.Forms
(
	ID			INT IDENTITY (1,1) NOT NULL,
	FirstName	NVARCHAR(64) NOT NULL,
	LastName	NVARCHAR(128) NOT NULL,
	DOB			DateTime NOT NULL,
	NewAddress		NVARCHAR(128) NOT NULL,
	City		NVARCHAR(128) NOT NULL,
	NewState	NVARCHAR(64) NOT NULL,
	Zip			INT NOT NULL,
	County		NVARCHAR(128) NOT NULL,
	CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO dbo.Forms (FirstName, LastName, DOB, NewAddress, City, NewState, Zip, County) VALUES
	('Buffy','Summers','1981-01-19 00:00:00','1630 Revello Drive','Sunnydale','California','95037', 'Santa Barbara'),
	('Xander','Harris','1981-01-25 00:00:00','1630 Revello Drive','Sunnydale','California','95037' ,'Santa Barbara'),
	('Willow','Rosenberg','1955-05-10 00:00:00','1630 Revello Drive','Sunnydale','California','95037', 'Santa Barbara'),
	('Rupert','Giles','1981-01-28 00:00:00','1630 Main St.','Sunnydale','California','95037', 'Santa Barbara'),
	('Spike','Pratt','1797-04-02 00:00:00','Sunnydale Cemetery','Sunnydale','California','95037', 'Santa Barbara');
GO
```

down.sql deletes the table
```bash
DELETE FROM Forms;
```

## Model and Context classes
Next I built a model class
```bash
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Form
    {
        public int ID { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "Address")]
        public string NewAddress { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "State")]
        public string NewState { get; set; }

        [Display(Name = "Zip")]
        public int Zip { get; set; }

        [Display(Name = "County")]
        public string County { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} DOB = {DOB} {NewAddress} {City} {NewState} Zip = {Zip}";
        }
    }
}
```
and then I created a DAL (Data Access Layer) folder where I later built my context class
```bash
using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class FormContext : DbContext
    {
        public FormContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<Form> Forms { get; set; }
    }
}

```

## Connection string
Next I added a connection string to my Web.config file. This also took a long time before I got everything correct so it connected to my db.
```bash
<connectionStrings>
   <add name="OurDBContext" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;
   AttachDbFilename=C:\Users\pc\Desktop\460\HW5db\HW5\HW5\APP_DATA\Database1.MDF;Integrated Security=True" providerName="System.Data.SqlClient"/>
 </connectionStrings>
```
## controller
Next I made the controller and action methods.

FormController:
```bash
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

```

HomeController:
```bash
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW5.Models;
using System.Data.Entity;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

}
```

## views
I created three views one as a basic home page with the option to fill out a form or view the table.

```bash
@{
    ViewBag.Title = "Home";
}
<div class="page-header text-center">
    <h2>DMV Change of Address</h2>
</div>
<div class="container">
    <div class="row text-center">
        <div class="btn-group">
            @Html.ActionLink("Change of Address Form", "Create", "Forms", null, new { @class = "btn btn-default" })
        </div>
        <br />
        <br/>
        <div class="btn-group">
            @Html.ActionLink("View Table", "Index", "Forms", null, new { @class = "btn btn-default" })
        </div>
    </div>
</div
```

The second view was the form which allowed the user to enter their information.

```bash

@model HW5.Models.Form
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
                @Html.LabelFor(model => model.FirstName, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.LastName, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.DOB, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.DOB, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.DOB, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.City, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.City, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.City, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.NewAddress, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.NewAddress, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.NewAddress, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.NewState, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.NewState, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.NewState, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.Zip, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.Zip, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Zip, "", new { @class = "text-danger" })
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.County, new { htmlAttributes = new { @class = "control-label" } })
                @Html.EditorFor(model => model.County, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.County, "", new { @class = "text-danger" })
            </div>


            <div class="form-group">
                <div>
                    <input type="submit" value="Create" class="btn btn-default" />
                </div>
            </div>
</div>
    }
<div>
    @Html.ActionLink("Back", "Index")
</div>
```
The third view showed the table
```bash
@model IEnumerable<HW5.Models.Form>

@{
    ViewBag.Title = "Index";
}

<p>
    @Html.ActionLink("Change of Address Form", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.DOB)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.NewAddress)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.City)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.NewState)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Zip)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.County)
        </th>
        <th></th>
    </tr>

    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.FirstName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.LastName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.DOB)
            </td>
            <th>
                @Html.DisplayFor(modelItem => item.NewAddress)
            </th>
            <th>
                @Html.DisplayFor(modelItem => item.City)
            </th>
            <th>
                @Html.DisplayFor(modelItem => item.NewState)
            </th>
            <th>
                @Html.DisplayFor(modelItem => item.Zip)
            </th>
            <th>
                @Html.DisplayFor(modelItem => item.County)
            </th>
        </tr>
    }

</table>
```
## Demo
Below you can see the home page with the two options
![](img/dmv1.PNG?raw=true)
The initial table with it's pre entered entries
![](img/tableBefor.PNG?raw=true)
The form for users to input their information
![](img/formdmv.PNG?raw=true)
The updated table after users submit their form
![](img/tableAfter.PNG?raw=true)
