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